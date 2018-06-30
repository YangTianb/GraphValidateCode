using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphValidateCode.Controllers
{
    [Produces("application/json")]
    [Route("api/Validate")]
    public class ValidateController : Controller
    {
        #region 参数
        //裁剪的小图大小
        private const int _shearSize = 40;
        //原始图片所在路径 300*300
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/src/300_300/");
        //原始图片数量
        private const int _ImgNum = 60;
        //原始图片宽px
        private int _ImgWidth = 300;
        //原始图片高px
        private int _ImgHeight = 300;
        //裁剪位置X轴最小位置
        private int _MinRangeX = 30;
        //裁剪位置X轴最大位置
        private int _MaxRangeX = 240;
        //裁剪位置Y轴最小位置
        private int _MinRangeY = 30;
        //裁剪位置Y轴最大位置
        private int _MaxRangeY = 200;
        //裁剪X轴大小 裁剪成20张上10张下10张
        private int _CutX = 30;
        //裁剪Y轴大小 裁剪成20张上10张下10张
        private int _CutY = 150;
        //小图相对原图左上角的x坐标  x坐标保存到session 用于校验
        private int _PositionX;
        //小图相对原图左上角的y坐标  y坐标返回到前端
        private int _PositionY;
        //action命令列表
        private string[] actionList = { "getcode", "check", "checkresult" };
        //图片规格列表 默认300*300
        private string[] imgspecList = { "300*300", "300*200", "200*100" };
        //允许误差 单位像素
        private const int _deviationPx = 2;
        //是否跨域访问 在将项目做成第三方使用时可用跨域解决方案 所有的session替换成可共用的变量(Redis)
        private Boolean _isCallback = false;
        //最大错误次数
        private const int _MaxErrorNum = 4;
        #endregion
    }
}