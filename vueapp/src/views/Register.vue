<template>
  <div class="login">
    <div class="title">注册新账户</div>
    <van-form @submit="Register()">
      <div class="row">
        <van-field
          v-model="form.UserId"
          label="用户名"
          placeholder="请输入用户名"
          required
          :rules="[{ required: true, message: '必填' }]"
        />
      </div>
      <div class="row">
        <van-field
          v-model="form.UserTel"
          label="手机号"
          placeholder="请输入手机号"
          required
          :rules="[{ required: true, message: '必填' }]"
        />
      </div>
      <div class="row">
        <van-field
          v-model="form.Password"
          label="密码"
          placeholder="请输入密码"
          type="password"
          required
          :rules="[{ required: true, message: '必填' }]"
        />
      </div>
      <div class="row">
        <van-button native-type="submit" type="primary" block>注册</van-button>
      </div>
    </van-form>
    <div class="row">
      <van-button @click="$universal.ToView('Login')" type="info" block
        >已有账号？去登录</van-button
      >
    </div>
    <div class="row back-home" @click="$universal.ToView('Home')">返回首页</div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        UserId: "",
        UserTel: "",
        Password: "",
      },
    };
  },
  methods: {
    Register() {
      let _this = this;
      _this.$request.Post(
        "api/User/Register",
        {
          user: JSON.stringify(_this.form),
        },
        (res) => {
          localStorage.setItem("user", res.data.Dic.data);
          _this.$universal.ToView(res.data.ToUrl);
          _this.$toast.success({
            message: res.data.Msg,
            duration: 2000,
          });
        }
      );
    },
  },
};
</script>

<style>
.login {
  position: absolute;
  width: 100%;
  top: 40%;
  left: 50%;
  transform: translate(-50%, -50%);
}
.row {
  padding: 5px 10px;
}
.title {
  padding: 10px;
  font-size: 20px;
  font-weight: 700;
  text-align: center;
}
.back-home {
  text-align: right;
  font-size: 12px;
}
</style>
