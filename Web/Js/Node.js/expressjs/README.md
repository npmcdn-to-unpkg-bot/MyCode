# Nodejs基础中间件Connect #
### 前言 ###
“中间件”在软件领域是一个非常广的概念，除操作系统的软件都可以称为中间件。

Connect被定义为Node平台的中间件框架，从定位上看Connect一定是出众的，广泛兼容的，稳定的，基础的平台性框架。如果攻克Connect，会有助于我们更了解Node的世界。Express就是基于Connect开发的。

### 目录 ###

### 1. Connect介绍 ###
Connect是一个node中间件（middleware）框架。如果把一个http处理过程比作是污水处理，中间件就像是一层层的过滤网。每个中间件在http处理过程中通过改写request或（和）response的数据、状态，实现了特定的功能。这些功能非常广泛，下图列出了connect所有内置中间件和部分第三方中间件。

下图根据中间件在整个http处理流程的位置，将中间件大致分为3类：

1. Pre-Request 通常用来改写request的原始数据
2. Request/Response 大部分中间件都在这里，功能各异
3. Post-Response 全局异常处理，改写response数据等

### 2. Connect安装 ###

### 3. Connect内置中间件介绍 ###
22个内置中间件列表

logger: 用户请求日志中间件
csrf: 跨域请求伪造保护中间件
compress: gzip压缩中间件
basicAuth: basic认证中间件
bodyParser: 请求内容解析中间件
json: JSON解析中间件
urlencoded: application/x-www-form-urlencode请求解析中间件
multipart: multipart/form-data请求解析中间件
timeout: 请求超时中间件
cookieParser: cookie解析中间件
session: 会话管理中间件
cookieSession: 基于cookies的会话中间件
methodOverride: HTTP伪造中间件
reponseTime: 计算响应时间中间件
staticCache: 缓存中间件
static: 静态文件处理中间件
directory: 目录列表中间件
vhost: 虚拟二级域名映射中间件
favicon: 网页图标中间件
limit: 请求内容大小限制中间件
query: URL解析中间件
errorHadnler: 错误处理中间件

### 4. logger ###
描述：用来输出用户请求日志。
参数：options或者format字符串

已分离出connect，现在使用morgan
[morgan](https://github.com/expressjs/morgan)

### 5. cookieParser ###
描述:cookie解析中间件，解析Cookies的头通过req.cookies得到cookies。还可以通过req.secret加密cookies。