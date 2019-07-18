using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace HalconWrapper._3D
{
    public class test
    {
        public void a()
        {
            BoundingBox_3D a = new BoundingBox_3D(1);
            var gbg = (HTuple)a;

            Points_3D points1 = new Points_3D(1);
            Points_3D points2 = new Points_3D(1);
            ListPoints_3D listPoints_3D = new ListPoints_3D();
            listPoints_3D.Register_object_model_3d_pair(points1, points2);
        }
    }



    /**生成包络体
     * **/
    public class BoundingBox_3D
    {
        public HTuple pose;
        public HTuple lengthX;
        public HTuple lengthY;
        public HTuple lengthZ;
        public static HTuple axis_aligned = "axis_aligned";


        /**生成boundingbox的函数
         * **/
        public  BoundingBox_3D(HTuple model3D)
        {
            HOperatorSet.SmallestBoundingBoxObjectModel3d
                (model3D, axis_aligned, out pose, out lengthX, out lengthY, out lengthZ);
        }


        /**BoundingBox_3D->(3d object)HTuple
         * 返回的Htuple就是模型
         * **/
        public static explicit operator HTuple(BoundingBox_3D model3D)
        {
            HTuple boxModel3d;
           // HOperatorSet.GenEmptyObjectModel3d(out boxModel3d);
            HOperatorSet.GenBoxObjectModel3d(model3D.pose, model3D.lengthX, model3D.lengthY, model3D.lengthZ, out boxModel3d);
            return boxModel3d;
        }


        /**TODO:显示boundingbox
         * **/
        public void Display()
        {
         // HOperatorSet.ClearObjectModel3d(this.)
        }

    }


    /**Register_object_model_3d_pair返回值
     * **/
    public struct PairRegesterResult
    {
        public HTuple pose, score;
    }


    /**点云数据结构
     * **/
    public class Points_3D : BaseMethord
    {
        //点云对象
        public HTuple Pointclouds;


        /**构造函数
         * **/
        public Points_3D(HTuple points)
        {
            //HOperatorSet.GenEmptyObjectModel3d(out Pointclouds);
            //HOperatorSet.CopyObjectModel3d
            HOperatorSet.CopyObjectModel3d(points,Enum2Htuple(Attribute.all),out this.Pointclouds);
        }
        public Points_3D(HTuple X, HTuple Y, HTuple Z)
        {
            //HOperatorSet.GenEmptyObjectModel3d(out Pointclouds);
            HOperatorSet.GenObjectModel3dFromPoints(X, Y, Z, out Pointclouds);
        }
        public Points_3D(double[] X, double[] Y, double[] Z)
        {
            HTuple xArry = new HTuple();
            xArry.DArr = X;
            HTuple yArry = new HTuple();
            yArry.DArr = Y;
            HTuple zArry = new HTuple();
            zArry.DArr = Z;
            //HOperatorSet.GenEmptyObjectModel3d(out Pointclouds);
            HOperatorSet.GenObjectModel3dFromPoints(xArry, yArry, zArry, out Pointclouds);
        }
        public Points_3D(string X, string Y, string Z)
        {
            //X,Y,Z代表符合HTuple的文件路径
            HTuple x = new HTuple();
            HTuple y = new HTuple();
            HTuple z = new HTuple();
            HOperatorSet.ReadTuple(X,out x);
            HOperatorSet.ReadTuple(Y, out y);
            HOperatorSet.ReadTuple(Z, out z);
            //HOperatorSet.GenEmptyObjectModel3d(out Pointclouds);
            HOperatorSet.GenObjectModel3dFromPoints(x, y, z, out Pointclouds);
        }

        /**获取点云的坐标
         * **/
        public double[] GetCoordX(ModelParams para = ModelParams.point_coord_x)
        {
            HTuple X = GetParamValue(para);
            double[] arry = X.ToDArr();
            return arry;
        }
        public double[] GetCoordY(ModelParams para = ModelParams.point_coord_y)
        {
            HTuple Y = GetParamValue(para);
            double[] arry =Y.ToDArr();
            return arry;
        }
        public double[] GetCoordZ(ModelParams para = ModelParams.point_coord_z)
        {
            HTuple Z = GetParamValue(para);
            double[] arry = Z.ToDArr();
            return arry;
        }


        /**获取点云的属性，默认为获取点云个数
         * **/
        public HTuple GetParamValue(ModelParams para= ModelParams.num_points)
        {
            HTuple genPara = Enum2Htuple(para);
            HTuple result=new HTuple();
            HOperatorSet.GetObjectModel3dParams(Pointclouds, genPara, out result);
            return result;
        }


        /**获取外包络矩形
         * **/
        public double[] GetBoundingBox(ModelParams para = ModelParams.bounding_box1)
        {
            HTuple boundingBox = GetParamValue(para);
            double[] arry = boundingBox.ToDArr();//获取2个点，2个点可以转换成一个立方体
            return arry;
        }


        /**设置点云的色彩
         * **/
        public void SetRGB()
        {
       //     HOperatorSet.SetObjectModel3dAttrib()
        }


        /**释放点云
         * **/
        public void Dispose()
        {
            //清除点
            HOperatorSet.ClearObjectModel3d(this.Pointclouds);
        }


        /**拷贝当前点云
         * 注意，这里只拷贝了当前点云，没有拷贝里面存储的配准点云
         * **/
        public Points_3D Copy()
        {
            Points_3D p = new Points_3D(this.Pointclouds);
            return p;
        }
    }


    /**点云拼接数据结构
     * **/
    public class ListPoints_3D: BaseMethord
    {
        List<PairRegesterResult> pairRegesters;
        List<Points_3D> registePointsList;


        /**构造函数
         * **/
        public ListPoints_3D()
        {
            pairRegesters = new List<PairRegesterResult>();
            registePointsList = new List<Points_3D>();
        }
        public ListPoints_3D(List<PairRegesterResult> pairRegesters, List<Points_3D> registePointsList)
        {
            this.pairRegesters = pairRegesters;
            this.registePointsList = registePointsList;
        }

        /**对输入的点云进行注册
         *  PreviousOM3 : 基准点云
         *  ObjectModel3D ： 需要配准的点云
         * **/
        public void Register_object_model_3d_pair(Points_3D ObjectModel3D, Points_3D PreviousOM3)
        {
            HTuple methord = Enum2Htuple(Methord.matching);
            HTuple genParamName = Enum2Htuple(GenParamName.default_parameters);
            HTuple genParamValue = Enum2Htuple(GenParamValue.accurate);
            HTuple pose, score;
            HOperatorSet.RegisterObjectModel3dPair
                (ObjectModel3D.Pointclouds, PreviousOM3.Pointclouds, methord, genParamName, genParamValue, out pose, out score);
            PairRegesterResult regesterResult = new PairRegesterResult();
            regesterResult.pose = pose;
            regesterResult.score = score;
            
            //保存点云和变换矩阵
            pairRegesters.Add(regesterResult);
            if (registePointsList.Count == 0) registePointsList.Add(PreviousOM3);
            registePointsList.Add(ObjectModel3D);
        }


        /**全局注册
         * 返回一个融合好的模型
         * **/
        public Points_3D Register_object_model_3d_global()
        {
            HTuple HomMat3DRefined, Score;
            HTuple modelHandle = GetModels();
            HTuple poseHandle = Pose2Mat();
            HOperatorSet.RegisterObjectModel3dGlobal(modelHandle, poseHandle, "previous",
          new HTuple(),Enum2Htuple(GenParamName.max_num_iterations), 1, out HomMat3DRefined, out Score);
            HTuple affinedModel = HalconWrapper.Affine_trans_object_model_3d(modelHandle, HomMat3DRefined);
            Points_3D unionedPoints = HalconWrapper.Union_object_model_3d(affinedModel);

            HOperatorSet.ClearObjectModel3d(affinedModel);
            return unionedPoints;
        }



        /**获取所有点云的句柄集合
         * **/
        public HTuple GetModels()
        {
            HTuple modelHandle = new HTuple();
            for (int i = 0; i < registePointsList.Count; i++)
            {
                modelHandle.Append(registePointsList[i].Pointclouds);
            }
            return modelHandle;
        }


        /**当前Pose集合-》变换矩阵集合
         * **/
        private HTuple Pose2Mat()
        {
            HTuple PoseMat = new HTuple();
            HTuple tempPoseMat;
            for (int i = 0; i < pairRegesters.Count; i++)
            {
                HOperatorSet.PoseToHomMat3d(pairRegesters[i].pose, out tempPoseMat);
                PoseMat.Append(tempPoseMat);
            }
            return PoseMat;
        }


        /**释放模型内存，如果Points_3D加到了ListPoints_3D，那么只用在ListPoints_3D中释放一次就行了
         * **/
        public void Dispose()
        {
            foreach (var v in registePointsList)
            {
                v.Dispose();
            }
            pairRegesters.Clear();
            registePointsList.Clear();
        }


        /**获取变换矩阵集合，不包含最初的初始变换矩阵
         * **/
        public HTuple GetTransformMatrix()
        {
            HTuple HomMat3DStart;
            /**生成一个标准变换矩阵
             *1 0 0 0
             *0 1 0 0
             *0 0 1 0
             *0 0 0 1 
             * **/
            HOperatorSet.HomMat3dIdentity(out HomMat3DStart);

            HTuple transformMat = new HTuple();
            //pose转Mat的临时存储
            HTuple tempPoseMat;
            for (int i = 0; i < pairRegesters.Count; i++)
            {
                //Regester得到的pose转换成矩阵，既三维的变换矩阵
                HOperatorSet.PoseToHomMat3d(pairRegesters[i].pose,out tempPoseMat);
                //当前矩阵与对应的三维变换矩阵，计算出变换到标准点云所需要的变换矩阵
                HOperatorSet.HomMat3dCompose(HomMat3DStart, tempPoseMat,out HomMat3DStart);
                transformMat.Append(HomMat3DStart);
            }
            return transformMat;
        }


    }


    /**一些halcon的基本方法
     * **/
    public class BaseMethord
    {
        /**一个枚举转Htuple的私有方法
         * **/
        public static HTuple Enum2Htuple(object obj)
        {
            return obj.ToString();
        }


        /**保存模型
         * **/
        public  void SaveModel(HTuple model,string fileName,HTuple param,HTuple paramValue)
        {
            HTuple typle = Enum2Htuple(WriteObjFileType.om3);
            HOperatorSet.WriteObjectModel3d(model, typle, fileName, param, paramValue);
        }
    }


    public static class HalconWrapper
    {
        /**写代码注意事项：
         * 0. 生成的临时的模型Htuple 需要及时释放
         * **/


        /**采样
         * **/
        private static Points_3D Sample_object_model_3d(HTuple model, SampleMethord methord = SampleMethord.accurate, double sampleDistance = 1, SampleParams para = SampleParams.min_num_points, int minNumPoints = 1)
        {
            HTuple m = BaseMethord.Enum2Htuple(methord);
            HTuple p = BaseMethord.Enum2Htuple(para);
            HTuple sampledModel;
            HOperatorSet.SampleObjectModel3d(model, m, sampleDistance, p, minNumPoints, out sampledModel);
            Points_3D points_3D = new Points_3D(sampledModel);
            HOperatorSet.ClearObjectModel3d(sampledModel);
            return points_3D;
        }
        public static Points_3D Sample_object_model_3d(Points_3D model,SampleMethord methord=SampleMethord.accurate,double sampleDistance=1,SampleParams para=SampleParams.min_num_points,int minNumPoints=1)
        {
            return Sample_object_model_3d
                (model.Pointclouds, methord, sampleDistance, para, minNumPoints);
        }
        public static Points_3D Sample_object_model_3d(ListPoints_3D model, SampleMethord methord = SampleMethord.accurate, double sampleDistance = 1, SampleParams para = SampleParams.min_num_points, int minNumPoints = 1)
        {
            return Sample_object_model_3d
           (model.GetModels(), methord, sampleDistance, para, minNumPoints);
        }


        /**包络矩形
         * **/
        public static void Smallest_bounding_box_object_model_3d()
        {
          //  HOperatorSet.SmallestBoundingBoxObjectModel3d()
        }



        /**对model依据transformMat进行三维变换
         * **/
        public static HTuple Affine_trans_object_model_3d(HTuple model, HTuple transformMat)
        {
            HTuple transformedModel;
            HOperatorSet.AffineTransObjectModel3d(model, transformMat, out transformedModel);
            return transformedModel;
        }


        /**对多个点云进行融合
         * **/
        public static Points_3D Union_object_model_3d(ListPoints_3D model)
        {
            HTuple unionedModel;
            HOperatorSet.UnionObjectModel3d(model.GetModels(), "points_surface", out unionedModel);
            Points_3D points_3D = new Points_3D(unionedModel);
            HOperatorSet.ClearObjectModel3d(unionedModel);
            return points_3D;
        }
        public static Points_3D Union_object_model_3d(HTuple model)
        {
            HTuple unionedModel;
            HOperatorSet.UnionObjectModel3d(model, "points_surface", out unionedModel);
            Points_3D points_3D = new Points_3D(unionedModel);
            HOperatorSet.ClearObjectModel3d(unionedModel);
            return points_3D;
        }
    }
}
