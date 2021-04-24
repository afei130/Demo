import axios from 'axios'
import qs from "qs"
import { Toast } from 'vant';

function Post(api, params, func,loading = true) {
    if(loading){
        Toast.loading({
            message: "加载中...",
            duration: 0
        });
    }
    setTimeout(() => {
        axios.post(api, qs.stringify(params))
            .then((res) => {
                if (res.status === 200) {
                    // if (res.data.Code === 100) {
                    func(res);
                    // } else if (res.data.Code === 0) {
                    //     Toast.fail(res.data.Msg);
                    // }
                    Toast.clear();
                } else {
                    console.log(res);
                    Toast.clear();
                    Toast.fail({
                        message: "网络错误❌",
                        duration: 2000
                    });
                }
            })
            .catch((res) => {
                console.log(res);
                Toast.clear();
                Toast.fail({
                    message: "我叼,出错啦",
                    duration: 2000
                });
            });
    }, 1000)
}

function Get() { }

export default {
    Post,
    Get
}