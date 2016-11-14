
/*
##################################################################
Date扩展
*/
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { //author: meizz 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

Date.prototype.ConvertTimestamp = function () { //author: meizz 
    var timestamp = Date.parse(this);
    return "/Date\({time}\)".replace("{time}", timestamp);
}

/*
##################################################################
String扩展
*/
//测试是否是数字 
String.prototype.toJsonObj = function () {
    return eval('(' + this + ')');
}
//测试是否是数字 
String.prototype.isNumeric = function () {
    var tmpFloat = parseFloat(this);
    if (isNaN(tmpFloat))
        return false;
    var tmpLen = this.length - tmpFloat.toString().length;
    return tmpFloat + "0".Repeat(tmpLen) == this;
}
// 除去左边空白 
String.prototype.LTrim = function () {
    return this.replace(/^s+/g, "");
}
// 除去右边空白 
String.prototype.RTrim = function () {
    return this.replace(/s+$/g, "");
}
// 除去两边空白 
String.prototype.trimStr = function () {
    return this.replace(/(^s+)|(s+$)/g, "");
}

// 除去两边空白 
String.prototype.showInDict = function (dict) {
    return dict[this];
}

// /Date(1470803427200)/ 转时间
String.prototype.toFomatTime = function () {
    var str = this.replace('/Date\(', '').replace('\)/', '');
    var date = new Date(parseFloat(str));
    return date.Format("yyyy-MM-dd hh:mm:ss");
}

// /Date(1470803427200)/ 转时间
String.prototype.toFomatDate = function () {
    var str = this.replace('/Date\(', '').replace('\)/', '');
    var date = new Date(parseFloat(str));
    return date.Format("yyyy-MM-dd");
}

// /2016-08-29 12:10:00 转时间
String.prototype.toDateTime = function () {
    var str = this.toString();
    //str = this.replace('/Date\(', '').replace('\)/', '');
    var date = new Date(str);
    return date;
}

/*
##################################################################
分页公共方法
*/

var PageInfo = function (obj) {
    if (!obj) obj = {};

    if (!obj.PageIndex) obj.PageIndex = 1;

    if (!obj.Sort) obj.Sort = '';

    if (!obj.IsAsc) obj.IsAsc = true;

    return obj;
};
/*
* @id htmlId
* @columns json
* @url string
*/
var GridVue = function (prams) {
    //默认PageInfo参数
    var pageInfo = PageInfo();
    if (prams.defaultPram) {
        $.extend(pageInfo, prams.defaultPram);
    }

    var vue = new Vue({
        el: prams.id,
        data: {
            Columns: prams.columns,
            PageData: {
                Data: [],
                PageCount: 0,
                Total: 0
            },
            PageInfo: pageInfo,
        },
        methods: {
            OnPageChange: function (index) {
                this.PageInfo.PageIndex = index;
                //console.log(index)
                this.loadData();
            },
            OnSortClick: function (name) {
                this.PageInfo.Sort = name;
                this.PageInfo.IsAsc = !this.PageInfo.IsAsc;
                //console.log(this.PageInfo.SortAs, this.PageInfo.IsAsc)
                this.loadData();
            },
            loadData: function () {
                var v = this;
                //如果有参数获取方法，则先执行
                if (prams.getPramFunc) {
                    prams.getPramFunc(this.PageInfo);
                }
                $.post(prams.url, this.PageInfo, function (result) {
                    if (result.Success) {
                        v.PageData = result.Data;
                    } else {
                        bootbox.alert(result.Msg);
                    }
                })
            },
            flushData: function () {
                this.PageInfo.PageIndex = 1;
                this.loadData();
            }
        }
    });

    //默认先加载一次数据
    vue.loadData();

    return vue;
}

/**
###################################################界面公共
**/
function showLoading() {
    $("#loading-container").removeClass("loading-inactive")
}

function closeLoading() {
    $("#loading-container").addClass("loading-inactive")
}