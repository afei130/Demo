//跳转页面
import router from '@/router'
function ToView(viewName, params = {}) {
    router.push({
        name: viewName,
        query: params
    });
}

//消息提示框
import { Toast } from "vant";
function LoadingTips(message, type = 101, duration = 2000) {
    if (type === 101) {
        Toast.loading({
            message, duration
        });
    } else if (type === 100) {
        Toast.success({
            message, duration
        });
    } else {
        Toast.fail({
            message, duration
        });
    }
}

//格式化日期
function DateFormat(date,fmt = "yyyy-mm-dd HH:MM:SS") {
    date = new Date(date)
    let ret;
    const opt = {
        "y+": date.getFullYear().toString(),        // 年
        "m+": (date.getMonth() + 1).toString(),     // 月
        "d+": date.getDate().toString(),            // 日
        "H+": date.getHours().toString(),           // 时
        "M+": date.getMinutes().toString(),         // 分
        "S+": date.getSeconds().toString()          // 秒
        // 有其他格式化字符需求可以继续添加，必须转化成字符串
    };
    for (let k in opt) {
        ret = new RegExp("(" + k + ")").exec(fmt);
        if (ret) {
            fmt = fmt.replace(ret[1], (ret[1].length == 1) ? (opt[k]) : (opt[k].padStart(ret[1].length, "0")))
        }
    }
    return fmt;
}

export default {
    ToView,
    LoadingTips,
    DateFormat
}