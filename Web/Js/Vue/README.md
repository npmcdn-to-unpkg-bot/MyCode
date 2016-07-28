# Vue.js 练手 #

目录

[01 ... HelloWorld](#01)

[02 ... 双向绑定](#02)

[03 ... 渲染列表](#03)

[04 ... 处理用户输入](#04)

[05 ... 综合](#05)

[06 ... 实例](#06)

[07 ... 数据绑定语法](#07)

## HelloVue ##
<span id="01"></span>
[HelloVue](code/Getting Started/HelloWorld.html "点我一下") 
## 双向绑定 ##
<span id="02"></span>
[双向绑定](code/Getting Started/HelloWorld.html "点我一下")
## 渲染列表 ##
<span id="03"></span>
[渲染列表](code/Getting Started/HelloWorld.html "点我一下")
## 处理用户输入 ##
<span id="04"></span>
[处理用户输入](code/Getting Started/HelloWorld.html "点我一下")
## 综合 ##
<span id="05"></span>
[综合](code/Getting Started/HelloWorld.html "点我一下")

## Vue 实例 ##
### 构造器 ###
每个Vue.js应用的起步都是通过构造函数`Vue`创建一个Vue的根实例:
	
	var vm = new Vue({
		//选项
	})
一个Vue实例其实正是一个MVVm模式所描述的ViewModel，在实例化Vue时，需要传入一个**选项对象**，可以包含数据、模板、挂载元素、方法、生命周期钩子等选项。

可以扩展`Vue`构造器，从而用预定义选项创建可复用的组件构造器：

	var MyComponent = Vue.extend({
		//扩展选项
	})
	//所有MyComponent 实例都以预定义的扩展选项被创建
	var myComponentInstance = new MyComponent()

### 属性与方法 ###
每个Vue实例都会**代理**其`data`对象里所有的属性：

	var data = { a:1 }
	var vm = new Vue({
		data: data
	})
	vm.a === data.a // -> true
	//设置属性也会影响到原始数据
	vm.a = 2;
 	data.a // -> 2
	//...反之亦然
	data.a = 3
	vm.a // -> 3
只有这些被代理idea属性是**响应**的

	var data = { a: 1}
	var vm = new Vue({
		el: "#example",
		data: data
	})

	var $data === data; // -> true
	var $el === document.getElementById("example"); //->true
	// $watch是一个实例方法
	var $watch('a', function(newVal, oldVal)){
		// 这个回调将在vm.a改变后调用
	}

### 实例生命周期 ###
Vue实例在创建时有一系列初始化不走——例如，建立数据观察，编译模板，创建必要的数据绑定。在此过程中，它也将调用一些生命周期钩子，给自定义逻辑提供运行机会。created、 compiled、 ready 、destroyed， 钩子的this指向调用它的Vue实例。

## 数据绑定语法 ##
Vue.js的模板是基于DOM实现的，这意味着所有的Vue.js模板都是可解析的有效的HTML，且通过一些特殊的特性做了增强。Vue模板因而从根本上不同基于字符串的模板。

### 插值 ###

#### 文本 ####
数据绑定最基础的形式是文本插值，使用 “Mustache” 语法（双大括号）：

	<span>Message: {{ msg }}</span>

Mustache 标签会被相应数据对象的 msg 属性的值替换。每当这个属性变化时它也会更新。

你也可以处理单次插值，今后的数据变化就不会再引起插值更新了：

	<span>This will never change: {{* msg }}</span>

#### 原始的HTML ####
双 Mustache 标签将数据解析为纯文本而不是 HTML。为了输出真的 HTML 字符串，需要用三 Mustache 标签：

	<div>{{{ raw_html }}}</div>
内容以HTML字符串插入——数据绑定将被忽略。如果需要复用模板片段，应当使用partials

#### HTML特性 ####
Mustache标签也可用于HTML特性（Attribute）内

	<div id="item-{{ id }}"></div>

### 绑定表达式 ###
放在 Mustache 标签内的文本称为绑定表达式。在 Vue.js 中，一段绑定表达式由一个简单的 JavaScript 表达式和可选的一个或多个过滤器构成。

#### JavaScript 表达式 ####
{{ number + 1 }}

