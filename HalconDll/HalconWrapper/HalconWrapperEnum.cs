using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconWrapper._3D
{
    /**用于ListPoints_3D类，Register_object_model_3d_global()和register_object_model_3d_pair()
     * 参考资料：
     * file:F:/Halcon/doc/html/reference/operators/register_object_model_3d_global.html
     * file:F:/Halcon/doc/html/reference/operators/register_object_model_3d_pair.html
     * **/
    public enum Methord
    {
        icp, matching
    }
    public enum GenParamName
    {
        //HOperatorSet.Register_object_model_3d_global()的必要参数枚举
        max_num_iterations,               //最大数迭代
        //二者共同可用
        default_parameters,
        pose_ref_sub_sampling,
        rel_sampling_distance,
        //HOperatorSet.RegisterObjectModel3dPair()的必要参数枚举
        key_point_fraction,
        key_point_fraction_obj1,
        key_point_fraction_obj2,
        model_invert_normals,
        pose_ref_dist_threshold_abs,
        pose_ref_dist_threshold_rel,
        pose_ref_num_steps,
        rel_sampling_distance_obj1,
        rel_sampling_distance_obj2
    }
    public enum GenParamValue
    {
        fast,
        accurate,
        robust,
        //除了上述枚举，还可以使用自定义的Htple值
        //, 0.1, 0.25, 0.5, 1, true, false
    }


    /**用于get_object_model_3d_params(),比较重要
     * **/
    public enum ModelParams
    {
        blue,
        bounding_box1,//外包络矩形
        center,//中心
        diameter_axis_aligned_bounding_box,
        extended_attribute_names,
        green,
        has_distance_computation_data,
        has_extended_attribute,
        has_lines,
        has_point_normals,
        has_points,//模型是否包含点
        has_polygons,//模型是否包含多边形
        has_primitive_data,
        has_primitive_rms,//是否有基元的二次剩余误差
        has_segmentation_data,//是否有分割数据
        has_shape_based_matching_3d_data,//是否有形状匹配数据
        has_surface_based_matching_data,//是否有表面匹配数据
        has_triangles,//是否有三角形
        has_xyz_mapping,//是否有XYZ的映射
        lines,
        mapping_col,
        mapping_row, neighbor_distance, num_extended_attribute,
        num_lines, num_neighbors, num_neighbors_fast,
        num_points,
        num_polygons,
        num_primitive_parameter_extension,
        num_triangles,
        point_coord_x, point_coord_y, point_coord_z,//点的坐标
        point_normal_x, point_normal_y, point_normal_z,//法向量
        polygons,
        primitive_parameter,
        primitive_parameter_extension,
        primitive_parameter_pose,
        primitive_pose,
        primitive_rms,
        primitive_type,
        red,
        reference_point,
        score,
        triangles
    }


    /**用于 Sample_object_model_3d(Methord)采样
     * **/
    public enum SampleMethord
    {
        fast,
        accurate,
        accurate_use_normals,
        fast_compute_normals
    }
 
    
    /**用于 Sample_object_model_3d(Params)采样
      * **/
    public enum SampleParams
    {
        min_num_points,
        max_angle_diff
    }

    /**write_object_model_3d
     * 用于BaseMethord.SaveModel()
     * **/
    public enum WriteObjFileType
    {
        om3,
        dxf,
        obj,
        off,
        ply,
        ply_binary,
        stl,
        stl_ascii,
        stl_binary
    }


    /**用于Points_3D类，HoperatorSet.CopyObjectModel3d()
     * **/
    public enum Attribute
    {
        all,
        blue,
        distance_computation_data,
        extended_attribute,
        face_polygon,
        face_triangle,
        green,
        point_coord,
        point_normal,
        primitive_box,
        primitive_cylinder,
        primitive_plane,
        primitive_sphere,
        primitives_all,
        red,
        score,
        segmentation_data,
        shape_based_matching_3d_data,
        surface_based_matching_data,
        xyz_mapping
    }

}
