using Newtonsoft.Json;
using static UAPI.Type;

namespace UAPI
{
    /// <summary />
    public class TranslateType : TypeInterface
    {
        /// <summary>
        /// 指定要翻译的文本
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 翻译之后的文本
        /// </summary>
        [JsonProperty("translate")]
        public string TranslatedText { get; set; }
    }

    /// <summary>
    /// 语言代码
    /// </summary>
    public enum SupportLanguages
    {
        /// <summary>
        /// 阿姆哈拉语
        /// </summary>
        am,

        /// <summary>
        /// 阿拉伯语
        /// </summary>
        ar,

        /// <summary>
        /// 阿塞拜疆语
        /// </summary>
        az,

        /// <summary>
        /// 白俄罗斯语
        /// </summary>
        be,

        /// <summary>
        /// 保加利亚语
        /// </summary>
        bg,

        /// <summary>
        /// 孟加拉语
        /// </summary>
        bn,

        /// <summary>
        /// 波斯尼亚语(拉丁)
        /// </summary>
        bs_Latn,

        /// <summary>
        /// 加泰罗尼亚语
        /// </summary>
        ca,

        /// <summary>
        /// 宿务语
        /// </summary>
        ceb,

        /// <summary>
        /// 科西嘉语
        /// </summary>
        co,

        /// <summary>
        /// 捷克语
        /// </summary>
        cs,

        /// <summary>
        /// 威尔士语
        /// </summary>
        cy,

        /// <summary>
        /// 丹麦语
        /// </summary>
        da,

        /// <summary>
        /// 德语
        /// </summary>
        de,

        /// <summary>
        /// 希腊语
        /// </summary>
        el,

        /// <summary>
        /// 英语
        /// </summary>
        en,

        /// <summary>
        /// 世界语
        /// </summary>
        eo,

        /// <summary>
        /// 西班牙语
        /// </summary>
        es,

        /// <summary>
        /// 爱沙尼亚语
        /// </summary>
        et,

        /// <summary>
        /// 巴斯克语
        /// </summary>
        eu,

        /// <summary>
        /// 波斯语
        /// </summary>
        fa,

        /// <summary>
        /// 芬兰语
        /// </summary>
        fi,

        /// <summary>
        /// 法语
        /// </summary>
        fr,

        /// <summary>
        /// 弗里西语
        /// </summary>
        fy,

        /// <summary>
        /// 爱尔兰语
        /// </summary>
        ga,

        /// <summary>
        /// 苏格兰盖尔语
        /// </summary>
        gd,

        /// <summary>
        /// 加利西亚语
        /// </summary>
        gl,

        /// <summary>
        /// 古吉拉特语
        /// </summary>
        gu,

        /// <summary>
        /// 豪萨语
        /// </summary>
        ha,

        /// <summary>
        /// 夏威夷语
        /// </summary>
        haw,

        /// <summary>
        /// 希伯来语
        /// </summary>
        he,

        /// <summary>
        /// 印地语
        /// </summary>
        hi,

        /// <summary>
        /// 赫蒙语
        /// </summary>
        hmn,

        /// <summary>
        /// 克罗地亚语
        /// </summary>
        hr,

        /// <summary>
        /// 海地克里奥尔语
        /// </summary>
        ht,

        /// <summary>
        /// 匈牙利语
        /// </summary>
        hu,

        /// <summary>
        /// 亚美尼亚语
        /// </summary>
        hy,

        /// <summary>
        /// 印尼语
        /// </summary>
        id,

        /// <summary>
        /// 伊博语
        /// </summary>
        ig,

        /// <summary>
        /// 冰岛语
        /// </summary>
        @is,

        /// <summary>
        /// 意大利语
        /// </summary>
        it,

        /// <summary>
        /// 日语
        /// </summary>
        ja,

        /// <summary>
        /// 爪哇语
        /// </summary>
        jw,

        /// <summary>
        /// 格鲁吉亚语
        /// </summary>
        ka,

        /// <summary>
        /// 哈萨克语
        /// </summary>
        kk,

        /// <summary>
        /// 高棉语
        /// </summary>
        km,

        /// <summary>
        /// 卡纳达语
        /// </summary>
        kn,

        /// <summary>
        /// 韩语
        /// </summary>
        ko,

        /// <summary>
        /// 库尔德语
        /// </summary>
        ku,

        /// <summary>
        /// 吉尔吉斯语
        /// </summary>
        ky,

        /// <summary>
        /// 拉丁语
        /// </summary>
        la,

        /// <summary>
        /// 卢森堡语
        /// </summary>
        lb,

        /// <summary>
        /// 老挝语
        /// </summary>
        lo,

        /// <summary>
        /// 立陶宛语
        /// </summary>
        lt,

        /// <summary>
        /// 拉脱维亚语
        /// </summary>
        lv,

        /// <summary>
        /// 马尔加什语
        /// </summary>
        mg,

        /// <summary>
        /// 毛利语
        /// </summary>
        mi,

        /// <summary>
        /// 马其顿语
        /// </summary>
        mk,

        /// <summary>
        /// 马拉雅拉姆语
        /// </summary>
        ml,

        /// <summary>
        /// 蒙古语
        /// </summary>
        mn,

        /// <summary>
        /// 马拉地语
        /// </summary>
        mr,

        /// <summary>
        /// 马来语
        /// </summary>
        ms,

        /// <summary>
        /// 马耳他语
        /// </summary>
        mt,

        /// <summary>
        /// 缅甸语
        /// </summary>
        my,

        /// <summary>
        /// 苗语
        /// </summary>
        mww,

        /// <summary>
        /// 尼泊尔语
        /// </summary>
        ne,

        /// <summary>
        /// 荷兰语
        /// </summary>
        nl,

        /// <summary>
        /// 挪威语
        /// </summary>
        no,

        /// <summary>
        /// 齐切瓦语
        /// </summary>
        ny,

        /// <summary>
        /// 克雷塔罗奥托米语
        /// </summary>
        otq,

        /// <summary>
        /// 旁遮普语
        /// </summary>
        pa,

        /// <summary>
        /// 波兰语
        /// </summary>
        pl,

        /// <summary>
        /// 普什图语
        /// </summary>
        ps,

        /// <summary>
        /// 葡萄牙语
        /// </summary>
        pt,

        /// <summary>
        /// 罗马尼亚语
        /// </summary>
        ro,

        /// <summary>
        /// 俄语
        /// </summary>
        ru,

        /// <summary>
        /// 信德语
        /// </summary>
        sd,

        /// <summary>
        /// 僧伽罗语
        /// </summary>
        si,

        /// <summary>
        /// 斯洛伐克语
        /// </summary>
        sk,

        /// <summary>
        /// 斯洛文尼亚语
        /// </summary>
        sl,

        /// <summary>
        /// 萨摩亚语
        /// </summary>
        sm,

        /// <summary>
        /// 修纳语
        /// </summary>
        sn,

        /// <summary>
        /// 索马里语
        /// </summary>
        so,

        /// <summary>
        /// 阿尔巴尼亚语
        /// </summary>
        sq,

        /// <summary>
        /// 塞尔维亚语(西里尔)
        /// </summary>
        sr_Cyrl,

        /// <summary>
        /// 塞尔维亚语(拉丁)
        /// </summary>
        sr_Latn,

        /// <summary>
        /// 塞索托语
        /// </summary>
        st,

        /// <summary>
        /// 巽他语
        /// </summary>
        su,

        /// <summary>
        /// 斯瓦希里语
        /// </summary>
        sw,

        /// <summary>
        /// 瑞典语
        /// </summary>
        sv,

        /// <summary>
        /// 泰米尔语
        /// </summary>
        ta,

        /// <summary>
        /// 泰卢固语
        /// </summary>
        te,

        /// <summary>
        /// 塔吉克语
        /// </summary>
        tg,

        /// <summary>
        /// 泰语
        /// </summary>
        th,

        /// <summary>
        /// 菲律宾语
        /// </summary>
        tl,

        /// <summary>
        /// 克林贡语
        /// </summary>
        tlh,

        /// <summary>
        /// 土耳其语
        /// </summary>
        tr,

        /// <summary>
        /// 乌克兰语
        /// </summary>
        uk,

        /// <summary>
        /// 乌尔都语
        /// </summary>
        ur,

        /// <summary>
        /// 乌兹别克语
        /// </summary>
        uz,

        /// <summary>
        /// 越南语
        /// </summary>
        vi,

        /// <summary>
        /// 科萨语
        /// </summary>
        xh,

        /// <summary>
        /// 意第绪语
        /// </summary>
        yi,

        /// <summary>
        /// 约鲁巴语
        /// </summary>
        yo,

        /// <summary>
        /// 尤卡坦玛雅语
        /// </summary>
        yua,

        /// <summary>
        /// 中文(简体)
        /// </summary>
        zh,

        /// <summary>
        /// 文言文
        /// </summary>
        zh_lzh,

        /// <summary>
        /// 中文(繁体)
        /// </summary>
        zh_TW,

        /// <summary>
        /// 祖鲁语
        /// </summary>
        zu
    }
}