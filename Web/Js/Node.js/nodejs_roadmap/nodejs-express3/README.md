# Nodejs开发框架Express3.0开发手记–从零开始 #
http://blog.fens.me/nodejs-express3/
## 6. 路由功能 ##
* 访问路径：/，页面：index.html，不需要登陆，可以直接访问。
* 访问路径：/home，页面：home.html，必须用户登陆后，才可以访问。
* 访问路径：/login，页面：login.html，登陆页面，用户名密码输入正确，自动跳转到home.html
* 访问路径：/logout，页面：无，退出登陆后，自动回到index.html页面

打开app.js文件，在增加路由配置

	app.get('/', routes.index);
	app.get('/login', routes.login);
	app.post('/login', routes.doLogin);
	app.get('/logout', routes.logout);
	app.get('/home', routes.home);
ps：get为get请求，post为post请求，all为所有针对这个路径的请求