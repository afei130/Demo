let config = {
	url:""
};
if (process.env.NODE_ENV === "development") {
	//开发环境
	config.url = "http://localhost:49793/";
} else if (process.env.NODE_ENV === "production") {
	//生产环境
	config.url = "http://www.waibibapo.com:5000/";
}

export default config

