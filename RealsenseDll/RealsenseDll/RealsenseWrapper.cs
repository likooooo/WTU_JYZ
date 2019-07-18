using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel.RealSense;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace RealsenseWrapper
{
    /**realsense库的封装
     * **/
   public class RealsenseWrapper
    {
        //当前的配置
        private Config currentConfig;
        private PipelineProfile profile;
        private Pipeline pipeline;
        //当前帧
        private FrameSet currentFrameset;
        public FrameSet CurrentFrameset
        {
            get
            {
                return currentFrameset;
            } set
            {
                if (currentFrameset != null)
                    currentFrameset.Dispose();
                currentFrameset = value;

            }
        }

        //深度的尺寸原始单位m->mm是1000倍
        private float scala = 1;

        //定义Index =1 为左边的红外相机
        private readonly int infraredLeft = 1;
        private readonly int infraredRight = 2;

        //相机参数句柄
        private Module RGBModule;
        private Module DepthModule;
        private Module InfraredLeftModule;
        private Module InfraredRightModule;

        //彩色相机使能控制
        private bool colorFrameEnalbe;
        public bool ColorFrameEnable
        {
            get
            {
                return colorFrameEnalbe;
            }
            set
            {
                colorFrameEnalbe = value;

                if (RGBModule == null)
                    RGBModule = new Module(ModuleStream.Color);
                if (colorFrameEnalbe)
                    RGBModule.Enable(currentConfig);
                else
                    RGBModule.Disable(currentConfig);
            }
        }

        //深度相机使能控制
        private bool depthFrameEnalbe;
        public bool DepthFrameEnalbe
        {
            get
            {
                return depthFrameEnalbe;
            }
            set
            {
                depthFrameEnalbe = value;
                if (DepthModule == null)
                    DepthModule = new Module(ModuleStream.Depth);
                if (depthFrameEnalbe)
                    DepthModule.Enable(currentConfig);
                else
                    DepthModule.Disable(currentConfig);
            }
        }

        //红外相机使能控制
        private bool infraredLeftEnalbe;
        public bool InfraredLeftEnalbe
        {
            get
            {
                return infraredLeftEnalbe;
            }
            set
            {
                infraredLeftEnalbe = value;

                if (InfraredLeftModule == null)
                    InfraredLeftModule = new Module(ModuleStream.Infrared, infraredLeft);
                if (infraredLeftEnalbe)
                    InfraredLeftModule.Enable(currentConfig);
                else
                    InfraredLeftModule.Disable(currentConfig);
            }
        }
        private bool infraredRightEnalbe;
        public bool InfraredRightEnalbe
        {
            get
            {
                return infraredRightEnalbe;
            }
            set
            {
                if (InfraredRightModule == null)
                    InfraredRightModule = new Module(ModuleStream.Infrared, infraredRight);
                infraredRightEnalbe = value;
                if (infraredRightEnalbe)
                    InfraredRightModule.Enable(currentConfig);
                else
                    InfraredRightModule.Disable(currentConfig);
            }
        }


        /**构造函数
         * **/
        public RealsenseWrapper()
        {
            if (GetRealsenseDevice().Count <= 0)
                throw new Exception("没有找到realsense设备");
            currentConfig = new Config();
            pipeline = new Pipeline();
        }


        /********************************************************************
         * 下面是realsense控制部分
         *********************************************************************/


        /**打开realsense
         * **/
        public void Start()
        {
            profile = pipeline.Start();
        }
        public void StartWithCfg()
        {

            profile = pipeline.Start(currentConfig);
        }


        /**关闭realsense
         * **/
        public void Stop()
        {
            pipeline.Stop();
            profile.Dispose();
        }


        /**重启realsense，如果修改了相机使能，要生效需要执行ReStart()
         * **/
        public void ReStart()
        {
            Stop();
            Start();
        }


        /**更新一帧数据
         * **/
        public bool UpdateFrame()
        {
            FrameSet frames;
            for (int i = 0; i < 100; i++)
            {

                if (pipeline.TryWaitForFrames(out frames))
                {
                    CurrentFrameset = frames;
                    return true;
                }
            }
            return false;
        }


        /********************************************************************
         * 下面是数据处理部分，以Frameset处理为主
         *********************************************************************/


        /**获取当前连接的realsense设备集合
         * **/
        private DeviceList GetRealsenseDevice()
        {
            Context ctx = new Context();
            var list = ctx.QueryDevices();
            ctx.Dispose();
            return list;
        }


        /**获取深度单位
         * **/
        public float GetDepthScala()
        {
            if (profile != null)
                return 1 / profile.Device.Sensors[0].DepthScale;
            else
                return -1;
        }


        /**从当前帧数据获取图像数据
         * **/
        public RealsenseImage GetImage(ModuleStream moduleStream, int index = -1)
        {
            switch (moduleStream)
            {
                case ModuleStream.Color:
                    return GetRgbImage();
                case ModuleStream.Depth:
                    return GetDepthImage();
                case ModuleStream.Infrared:
                    return GetInfraredImage(index);
                default:
                    throw new Exception("预期之外的ModuleStream："+ moduleStream);
            }
        }
        public RealsenseImage GetRgbImage()
        {
            if (CurrentFrameset.ColorFrame == null)
                throw new Exception("在获取图像时，ColorFrame值为空,可能Depth未启用");
            RealsenseImage image = new RealsenseImage(
              CurrentFrameset.ColorFrame.Width,
              CurrentFrameset.ColorFrame.Height,
              CurrentFrameset.ColorFrame.Stride,
              CurrentFrameset.ColorFrame.BitsPerPixel);
            CurrentFrameset.ColorFrame.CopyTo<byte>(image.Data);
            return image;
        }
        public RealsenseImage GetDepthImage()
        {
            if (CurrentFrameset.DepthFrame == null)
                throw new Exception("在获取图像时，ColorFrame值为空,可能Depth未启用");
            RealsenseImage image = new RealsenseImage(
              CurrentFrameset.DepthFrame.Width,
              CurrentFrameset.DepthFrame.Height,
              CurrentFrameset.DepthFrame.Stride,
              CurrentFrameset.DepthFrame.BitsPerPixel);
            CurrentFrameset.DepthFrame.CopyTo<byte>(image.Data);
            return image;
        }
        public RealsenseImage GetInfraredImage(int index)
        {
            RealsenseImage image;
            switch (index)
            {
                case 1:
                    if (CurrentFrameset.InfraredFrame == null)
                        throw new Exception("在获取图像时，InfraredFrame值为空,可能Infrared未启用");
                    image = new RealsenseImage(
                      CurrentFrameset.InfraredFrame.Width,
                      CurrentFrameset.InfraredFrame.Height,
                      CurrentFrameset.InfraredFrame.Stride,
                      CurrentFrameset.InfraredFrame.BitsPerPixel);
                    CurrentFrameset.InfraredFrame.CopyTo<byte>(image.Data);
                    return image;
                case 2:
                    if (CurrentFrameset.FishEyeFrame == null)
                        throw new Exception("在获取图像时，FishEyeFrame值为空,可能Depth未启用");
                    image = new RealsenseImage(
                      CurrentFrameset.FishEyeFrame.Width,
                      CurrentFrameset.FishEyeFrame.Height,
                      CurrentFrameset.FishEyeFrame.Stride,
                      CurrentFrameset.FishEyeFrame.BitsPerPixel);
                    CurrentFrameset.FishEyeFrame.CopyTo<byte>(image.Data);
                    return image;
                default:
                    throw new Exception("当前Index定义为1或2");
            }
        }


        /**对当前帧进行对齐（在任何计算之前进行这一步操作）
         * **/
        public void Aligin(ModuleStream module= ModuleStream.Color)
        {
            
            using (Align align = new Align(Module.GetRsStream(module)))
            {
                CurrentFrameset = align.Process(CurrentFrameset);
            }
        }


        /**图像数据转换 RealsenseImage-》Bitmap
         * **/
        public Bitmap GetBitmap(RealsenseImage realsenseImage)
        {
            return realsenseImage.GetBitmap();
        }


        /**获取点云
         * **/
        public RealsensePointclouds GetPointclouds( float minx, float maxx, float miny, float maxy, float minz, float maxz)
        {
            RealsensePointclouds rsPoints;
            using (PointCloud pc = new PointCloud())
            using (var depth = CurrentFrameset.DepthFrame)
            {
                //映射纹理
                if (CurrentFrameset.ColorFrame != null)
                    pc.MapTexture(CurrentFrameset.ColorFrame);
                else if(CurrentFrameset.InfraredFrame!=null)
                    pc.MapTexture(CurrentFrameset.InfraredFrame);
                using (var points = pc.Process(depth).As<Points>())
                {
                    rsPoints = new RealsensePointclouds(points, scala, minx,maxx,miny,maxy,minz,maxz);
                  
                }
            }
            return rsPoints;
        }


    }


    /**realsense中提取的图片的数据结构
     * **/
    public class RealsenseImage
    {
        public int Width;
        public int Height;
        public int Stride;
        public int BitsPerPixel;
        public byte[] Data;


        /**构造函数
         * **/
        public RealsenseImage(int Width, int Height, int Stride, int BitsPerPixel)
        {
            this.Width = Width;
            this.Height = Height;
            this.Stride = Stride;
            this.BitsPerPixel = BitsPerPixel;
            Data = new byte[Stride * BitsPerPixel * Height];
        }


        /**数据转换RealsenseImage-》Bitmap
         * **/
        public Bitmap GetBitmap()
        {
            PixelFormat pixelFormat;
            switch (BitsPerPixel)
            {
                case 8:
                    pixelFormat = PixelFormat.Format8bppIndexed;
                    break;
                case 16:
                    pixelFormat = PixelFormat.Format16bppRgb565;
                    break;
                case 24:
                    pixelFormat = PixelFormat.Format24bppRgb;
                    break;
                default:
                    throw new Exception("RealsenseImage.GetBitmap()未定义BitsPerPixel的值："+ BitsPerPixel);
            }

            //创建一个bitmap对象
            Bitmap bmp = new Bitmap(Width, Height, pixelFormat);
          
            //通过bmp.LockBits()来复制值，这个方式效率高
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, Width, Height),
             ImageLockMode.WriteOnly, pixelFormat);
            IntPtr iptr = bmpData.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(Data, 0, iptr, Stride * Height);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
    }


    /**点云
     * **/
    public class RealsensePointclouds
    {
        //xyz
        public Vertex[] Points { get; set; }
        //uvuv
        public TextureCoordinate[] Textures;
        //纹理图片
        public RealsenseImage textureImage;

        private float Scala;


        /**构造函数(存在问题)
         * 纹理没解决
         * **/
        public RealsensePointclouds(Points points, float scala,
            float minx, float maxx,float miny,float maxy,float minz,float maxz)
        {
            Scala = scala;
            Points = new Vertex[points.Count];
            Textures = new TextureCoordinate[points.Count];
            //点云
            points.CopyVertices(Points);
            //纹理
            points.CopyTextureCoords(Textures);

            //TODO：去0,在正负1.5的范围内     
            Points = Points;
             //   .Where(s => (s.x != 0 && s.y != 0 && s.z != 0))
             //.Where(s => s.x > minx && s.x < maxx && s.y > miny && s.y < maxy && s.z > minz && s.z < maxz)
             //  .ToArray();
            Textures = Textures.Where(s => (s.u != 0 && s.v != 0)).ToArray();
        }
        public RealsensePointclouds(Vertex[] points, float scala)
        {
            this.Scala = scala;
            this.Points = points;
        }
        public RealsensePointclouds(double[] X, double[] Y, double[] Z, float scala)
        {
            Scala = scala;
            Points = new Vertex[X.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                Vertex vertex = new Vertex();
                vertex.x =(float) X[i];
                vertex.y = (float)Y[i];
                vertex.z = (float)Z[i];
                Points[i] = vertex;
            }
        }
        public RealsensePointclouds(float[] X,float[] Y,float[] Z, float scala)
        {
            Scala = scala;
            Points = new Vertex[X.Length];
            for (int i = 0; i < Points.Length; i++)
            {
                Vertex vertex = new Vertex();
                vertex.x = X[i];
                vertex.y = Y[i];
                vertex.z = Z[i];
                Points[i] = vertex;
            }
        }


        /**点云以Htuple的格式存储
         * **/
        public void SavePoints2Htuple(string name)
        {
         //   int Id = 0;
            StreamWriter sx = new StreamWriter(File.Create(name + "_Htuple_x" + ".txt"));
            StreamWriter sy = new StreamWriter(File.Create(name + "_Htuple_y" + ".txt"));
            StreamWriter sz = new StreamWriter(File.Create(name + "_Htuple_z" + ".txt"));

            sx.WriteLine(Points.Count().ToString());
            sy.WriteLine(Points.Count().ToString());
            sz.WriteLine(Points.Count().ToString());

            for (int i = 0; i < Points.Count(); i++)
            {
                sx.WriteLine("2 " + (Points[i].x* Scala).ToString());
                sy.WriteLine("2 " +( Points[i].y* Scala).ToString());
                sz.WriteLine("2 " +( Points[i].z* Scala).ToString());
            }
            sx.Close();
            sy.Close();
            sz.Close();
        }


        /**返回坐标值，3行N列
         * 0，1，2行分别代表Xyz
         * **/
        public Vertex[] GetPointsCoord()
        {
            return Points;
        }


        /**返回X坐标
         * **/
        public double[] GetPointsCoordX()
        {
            double[] arry = Points.Select(s => (double)s.x).ToArray();
            return arry;
        }


        /**返回Y坐标
         * **/
        public double[] GetPointsCoordY()
        {
            double[] arry = Points.Select(s => (double)s.y).ToArray();
            return arry;
        }


        /**返回Z坐标
         * **/
        public double[] GetPointsCoordZ()
        {
            double[] arry = Points.Select(s => (double)s.z).ToArray();
            return arry;
        }


        /**获取包络矩形
         * **/
        public double[] GetBoundingBox()
        {
            double[] boundingBox = new double[6];

            double[] x = GetPointsCoordX();
            double[] y = GetPointsCoordY();
            double[] z = GetPointsCoordZ();
            if (x.Length > 0)
            {
                boundingBox[0] = x.Min();
                boundingBox[1] = x.Max();
            }
            if (y.Length > 0)
            {
                boundingBox[2] = y.Min();
                boundingBox[3] = y.Max();
            }
            if (z.Length > 0)
            {
                boundingBox[4] = z.Min();
                boundingBox[5] = z.Max();
            }

            return boundingBox;
        }


        /**复制
         * **/
        public RealsensePointclouds Copy()
        {
            return new RealsensePointclouds(this.Points, this.Scala);
        }


        /**释放资源（未测试）
         * **/
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    /**单个点的数据结构
     * **/
    public struct Vertex
    {
        public float x;
        public float y;
        public float z;
    }


    /**纹理
     * **/
    public struct TextureCoordinate
    {
        public float u;
        public float v;
    }

    public struct Color
    {
        public int r;
        public int g;
        public int b;
    }
}
