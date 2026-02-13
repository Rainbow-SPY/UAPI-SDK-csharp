using System.Threading.Tasks;
using Rox.Runtimes;
using UAPI.IException;

namespace UAPI
{
    public partial class misc
    {
        /// <summary>
        /// 获取一组随机数字
        /// </summary>
        /// <param name="min">生成随机数的最小值（包含）。</param>
        /// <param name="max">生成随机数的最大值（包含）。</param>
        /// <param name="count">需要生成的随机数的数量。</param>
        /// <param name="allow_repeat">是否允许生成的多个数字中出现重复值。</param>
        /// <param name="allow_decimal">是否生成小（浮点）数。如果为 false，则只生成整数。</param>
        /// <param name="decimal_places">如果 allow_decimal=true，这里可以指定小数的位数。</param>
        /// <returns></returns>
        public static async Task<RandomNumberType> GetRandomNumberList(int min = 0, int max = 0, int count = 0,
            bool allow_repeat = false, bool allow_decimal = false, int decimal_places = 0)
        {
            var (result, statusCode) = await Interface.GetResult<RandomNumberType>(
                $"{_Request_Url}randomnumber?min={min}&max={max}&count={count}&allow_repeat={allow_repeat}&allow_decimal={allow_decimal}&decimal_places={decimal_places}");
            if (!Interface.IsGetSuccessful(result, "number", statusCode, new General.UAPIUnknowException(),
                    "GetRandomNumberList"))
                LogLibraries.WriteLog.Error("请求失败, 请重试");
            return result;
        }
    }
}