# Node.js 开发框架Express4.x #

## 1.建立项目 ##

## 2.目录结构 ##

bin，存放启动项目的脚本文件
node_modules，存放所有的项目依赖库
public，静态文件
route,路由文件（MVC中标的C，controller）
views，页面文件（Ejs模板）
package.json，项目依赖配置及开发者信息
app.js，应用核心配置文件

## 3.package.json项目配置 ##
package.json用于项目依赖配置及开发者信息，scripts属性是用于定义操作命令的，可以非常方便的增加启动命令，比如默认的start，用npm start代表执行node ./bin/www命令。

## 4.app.js核心文件 ##
从Express3.x升级到Express4.x，主要的变化就在app.js文件中

	// 加载依赖库，原来这个类库都封装在connect中，现在需地注单独加载
	var express = require('express'); 
	var path = require('path');
	var favicon = require('serve-favicon');
	var logger = require('morgan');
	var cookieParser = require('cookie-parser');
	var bodyParser = require('body-parser');
	
	// 加载路由控制
	var routes = require('./routes/index');
	//var users = require('./routes/users');
	
	// 创建项目实例
	var app = express();
	
	// 定义EJS模板引擎和模板文件位置，也可以使用jade或其他模型引擎
	app.set('views', path.join(__dirname, 'views'));
	app.set('view engine', 'ejs');
	
	// 定义icon图标
	app.use(favicon(__dirname + '/public/favicon.ico'));
	// 定义日志和输出级别
	app.use(logger('dev'));
	// 定义数据解析器
	app.use(bodyParser.json());
	app.use(bodyParser.urlencoded({ extended: false }));
	// 定义cookie解析器
	app.use(cookieParser());
	// 定义静态文件目录
	app.use(express.static(path.join(__dirname, 'public')));
	
	// 匹配路径和路由
	app.use('/', routes);
	//app.use('/users', users);
	
	// 404错误处理
	app.use(function(req, res, next) {
	    var err = new Error('Not Found');
	    err.status = 404;
	    next(err);
	});
	
	// 开发环境，500错误处理和错误堆栈跟踪
	if (app.get('env') === 'development') {
	    app.use(function(err, req, res, next) {
	        res.status(err.status || 500);
	        res.render('error', {
	            message: err.message,
	            error: err
	        });
	    });
	}
	
	// 生产环境，500错误处理
	app.use(function(err, req, res, next) {
	    res.status(err.status || 500);
	    res.render('error', {
	        message: err.message,
	        error: {}
	    });
	});
	
	// 输出模型app
	module.exports = app;
原来用于项目启动代码也被移到./bin/www的文件，www文件也是一个node的脚本，用于分离配置和启动程序。

## 5. Bootstrap界面框架 ##
创建Bootstrap界面框架，直接在index.ejs文件上面做修改。可以手动下载Bootstrap库放到项目中对应的位置引用，也可以通过bower来管理前端的Javascript库，参考文章 bower解决js的依赖管理。另外还可以直接使用免费的CDN源加载Bootstrap的css和js文件。下面我就直接使用Bootcss社区提供的CDN源加载Bootstrap。

编辑views/index.ejs文件

## 6. 路由功能 ##
路由功能，是Express4以后全面改版的功能。在应用程序加载隐含路由中间件，不用担心在中间件被装载相对于路由器中间件的顺序。定义路由的方式是不变的，路由系统中增加2个新的功能。

* app.route()函数，创建可链接的途径处理程序的路由路径。
* express.Router类，创建模块化安装路径的处理程序。

app.route方法会返回一个Route实例，它可以继续使用所有的HTTP方法，包括get,post,all,put,delete,head等。

	app.route('/users')
	  .get(function(req, res, next) {})
	  .post(function(req, res, next) {})	
express.Router类，则可以帮助我们更好的组织代码结构。在app.js文件中，定义了app.use('/', routes); routes是指向了routes目录下的index.js文件，./routes/index.js文件中，express.Router被定义使用，路径/*处理都会由routes/index.js文件里的Router来处理。如果我们要管理不同的路径，那么可以直接配置为多个不同的Router。
	
	app.use('/user', require('./routes/user').user);
	app.use('/admin', require('./routes/admin').admin);
	app.use('/', require('./routes'));

## 7. 程序代码 ##
对于刚接触Express4.x的朋友，可以直接从Github上面下载本文项目中的源代码，按照片文章中的介绍学习Express4，[https://github.com/bsspirit/nodejs-demo/tree/express4](https://github.com/bsspirit/nodejs-demo/tree/express4)

## 8. Express3.x和Express4.x的改动列表 ##
|Express 3|Express 4|
|---------|---------|
|express.bodyParser|body-parser + multer|
|express.compress|compression|
|express.cookieSession|cookie-session|
|express.cookieParser|cookie-parser|
|express.logger|morgan|
|express.session|express-session|
|express.favicon|serve-favicon|
|express.responseTime|response-time|
|express.errorHandler|errorhandler|
|express.methodOverride|method-override|
|express.timeout|connect-timeout|
|express.vhost|vhost|
|express.csrf|csurf|
|express.directory|serve-index|
|express.static|serve-static|