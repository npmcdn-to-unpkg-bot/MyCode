# AngularJS  #

## AngularJS 简介 ##

**AngularJS 是一个 JavaScript 框架**
https://github.com/angular/angular.js/releases

## AngularJS 表达式 ## 
AngularJS 表达式写在双大括号内：{{ expression }}。

AngularJS 表达式把数据绑定到 HTML，这与 ng-bind 指令有异曲同工之妙。

AngularJS 将在表达式书写的位置"输出"数据。

**AngularJS 表达式 与 JavaScript 表达式**
类似于 JavaScript 表达式，AngularJS 表达式可以包含字母，操作符，变量。 
与 JavaScript 表达式不同，AngularJS 表达式可以写在 HTML 中。
与 JavaScript 表达式不同，AngularJS 表达式不支持条件判断，循环及异常。
与 JavaScript 表达式不同，AngularJS 表达式支持过滤器。

## AngularJS指令 ##
AngularJS 通过被称为 指令 的新属性来扩展 HTML。

AngularJS 通过内置的指令来为应用添加功能。

AngularJS 允许你自定义指令。

### AngularJS 指令 ###
AngularJS 指令是扩展的 HTML 属性，带有前缀 ng-。

**ng-app** 指令初始化一个 AngularJS 应用程序。

**ng-init** 指令初始化应用程序数据。

**ng-model** 指令把元素值（比如输入域的值）绑定到应用程序。

### 数据绑定 ###
AngularJS 中的数据绑定，同步了 AngularJS 表达式与 AngularJS 数据。

{{ firstName }} 是通过 ng-model="firstName" 进行同步。

### 重复 HTML 元素 ###
ng-repeat 指令会重复一个 HTML 元素：

	<div ng-app="" ng-init="names=['Jani','Hege','Kai']">
	  <p>使用 ng-repeat 来循环数组</p>
	  <ul>
	    <li ng-repeat="x in names">
	      {{ x }}
	    </li>
	  </ul>
	</div>
ng-repeat 指令用在一个对象数组上：

	<div ng-app="" ng-init="names=[
		{name:'Jani',country:'Norway'},
		{name:'Hege',country:'Sweden'},
		{name:'Kai',country:'Denmark'}]">
	
		<p>循环对象：</p>
		<ul>
		  <li ng-repeat="x in names">
		    {{ x.name + ', ' + x.country }}
		  </li>
		</ul>
	</div> 

### ng-app 指令 ###
ng-app 指令定义了 AngularJS 应用程序的 根元素。
ng-app 指令在网页加载完毕时会自动引导（自动初始化）应用程序。 

### ng-init 指令 ###
ng-init 指令为 AngularJS 应用程序定义了 初始值。
通常情况下，不使用 ng-init。您将使用一个控制器或模块来代替它。

### ng-model 指令 ###
ng-model 指令 绑定 HTML 元素 到应用程序数据。
ng-model 指令也可以：

* 为应用程序数据提供类型验证（number、email、required）。
* 为应用程序数据提供状态（invalid、dirty、touched、error）。
* 为 HTML 元素提供 CSS 类。
* 绑定 HTML 元素到 HTML 表单。

### ng-repeat 指令 ###
ng-repeat 指令对于集合中（数组中）的每个项会 **克隆**一次 HTML 元素。

### 创建自定义的指令 ###
除了 AngularJS 内置的指令外，我们还可以创建自定义指令。
你可以使用 .directive 函数来添加自定义的指令。
要调用自定义指令，HTML 元素上需要添加自定义指令名。
使用驼峰法来命名一个指令， runoobDirective, 但在使用它时需要以 - 分割, runoob-directive:

	<body ng-app="myApp">
	<runoob-directive></runoob-directive>	
	<script>
	var app = angular.module("myApp", []);
	app.directive("runoobDirective", function() {
	    return {
	        template : "<h1>自定义指令!</h1>"
	    };
	});
	</script>	
	</body>

## AngularJS ng-model 指令  ##
ng-model 指令用于绑定应用程序数据到 HTML 控制器(input, select, textarea)的值。
### ng-model 指令 ###
ng-model 指令可以将输入域的值与 AngularJS 创建的变量绑定。
### 双向绑定 ###
双向绑定，在修改输入域的值时， AngularJS 属性的值也将修改
### 验证用户输入 ###

	<form ng-app="" name="myForm">
	    Email:
	    <input type="email" name="myAddress" ng-model="text">
	    <span ng-show="myForm.myAddress.$error.email">不是一个合法的邮箱地址</span>
	</form>
### 应用状态 ###
ng-model 指令可以为应用数据提供状态值(invalid, dirty, touched, error):

	<form ng-app="" name="myForm" ng-init="myText = 'test@runoob.com'">
	    Email:
	    <input type="email" name="myAddress" ng-model="myText" required></p>
	    <h1>状态</h1>
	    {{myForm.myAddress.$valid}}
	    {{myForm.myAddress.$dirty}}
	    {{myForm.myAddress.$touched}}
	</form>
### CSS 类 ###
ng-model 指令基于它们的状态为 HTML 元素提供了 CSS 类：

	<style>
	input.ng-invalid {
	    background-color: lightblue;
	}
	</style>
	<body>
	
	<form ng-app="" name="myForm">
	    输入你的名字:
	    <input name="myAddress" ng-model="text" required>
	</form>
ng-model 指令根据表单域的状态添加/移除以下类：

* ng-empty
* ng-not-empty
* ng-touched
* ng-untouched
* ng-valid
* ng-invalid
* ng-dirty
* ng-pending
* ng-pristine

## AngularJS Scope(作用域)  ##
Scope(作用域) 是应用在 HTML (视图) 和 JavaScript (控制器)之间的纽带。

Scope 是一个对象，有可用的方法和属性。

Scope 可应用在视图和控制器上。
### 如何使用 Scope ###
当你在 AngularJS 创建控制器时，你可以将 $scope 对象当作一个参数传递:

	<div ng-app="myApp" ng-controller="myCtrl">
		<h1>{{carname}}</h1>	
	</div>	
	<script>
	var app = angular.module('myApp', []);	
	app.controller('myCtrl', function($scope) {
	    $scope.carname = "Volvo";
	});
	</script>

当在控制器中添加 $scope 对象时，视图 (HTML) 可以获取了这些属性。
视图中，你不需要添加 $scope 前缀, 只需要添加属性名即可，如： {{carname}}。

### Scope 概述 ###
AngularJS 应用组成如下：

* View(视图), 即 HTML。
* Model(模型), 当前视图中可用的数据。
* Controller(控制器), 即 JavaScript 函数，可以添加或修改属性。

scope 是模型。 
scope 是一个 JavaScript 对象，带有属性和方法，这些属性和方法可以在视图和控制器中使用。

### Scope 作用范围 ###
了解你当前使用的 scope 是非常重要的。
在以上两个实例中，只有一个作用域 scope，所以处理起来比较简单，但在大型项目中， HTML DOM 中有多个作用域，这时你就需要知道你使用的 scope 对应的作用域是哪一个。

### 根作用域 ###
所有的应用都有一个 $rootScope，它可以作用在 ng-app 指令包含的所有 HTML 元素中。
$rootScope 可作用于整个应用中。是各个 controller 中 scope 的桥梁。用 rootscope 定义的值，可以在各个 controller 中使用。

	<div ng-app="myApp" ng-controller="myCtrl">
	
	<h1>{{lastname}} 家族成员:</h1>
	
	<ul>
	    <li ng-repeat="x in names">{{x}} {{lastname}}</li>
	</ul>
	
	</div>
	
	<script>
	var app = angular.module('myApp', []);
	
	app.controller('myCtrl', function($scope, $rootScope) {
	    $scope.names = ["Emil", "Tobias", "Linus"];
	    $rootScope.lastname = "Refsnes";
	});
	</script>

## AngularJS 控制器  ##
AngularJS 控制器 控制 AngularJS 应用程序的数据。
AngularJS 控制器是常规的 JavaScript 对象。

### AngularJS 控制器 ###
AngularJS 应用程序被控制器控制。

ng-controller 指令定义了应用程序控制器。

控制器是 JavaScript 对象，由标准的 JavaScript 对象的构造函数 创建。


## AngularJs实例 ##

### AngularJS 基础 ###
[AngularJS 控制器](code/try_ng_intro_controller.html)



