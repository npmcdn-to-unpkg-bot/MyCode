# Node.js Buffer(缓冲区) #
JavaScript 语言自身只有字符串数据类型，没有二进制数据类型。

但在处理像TCP流或文件流时，必须使用到二进制数据。因此在 Node.js中，定义了一个 Buffer 类，该类用来创建一个专门存放二进制数据的缓存区。

在 Node.js 中，Buffer 类是随 Node 内核一起发布的核心库。Buffer 库为 Node.js 带来了一种存储原始数据的方法，可以让 Node.js 处理二进制数据，每当需要在 Node.js 中处理I/O操作中移动的数据时，就有可能使用 Buffer 库。原始数据存储在 Buffer 类的实例中。一个 Buffer 类似于一个整数数组，但它对应于 V8 堆内存之外的一块原始内存。

## 创建Buffer类 ##

Node Buffer 类可以通过多种方式来创建。

### 方法 1 ###
创建长度为 10 字节的 Buffer 实例：

	var buf = new Buffer(10);

### 方法 2 ###
通过给定的数组创建 Buffer 实例：

	var buf = new Buffer([10, 20, 30, 40, 50]);

### 方法 3 ###
通过一个字符串来创建 Buffer 实例：

	var buf = new Buffer("www.runoob.com", "utf-8");
utf-8 是默认的编码方式，此外它同样支持以下编码："ascii", "utf8", "utf16le", "ucs2", "base64" 和 "hex"。

## 写入缓冲区 ##

### 语法 ###
写入 Node 缓冲区的语法如下所示：

	buf.write(string[, offset[, length]][, encoding]);
### 参数 ###
参数描述如下：

* **string** - 写入缓冲区的字符串。
* **offset** - 缓冲区开始写入的索引值，默认为 0 。
* **length** - 写入的字节数，默认为 buffer.length
* **encoding** - 使用的编码。默认为 'utf8' 。
* 
### 返回值 ###
返回实际写入的大小。如果 buffer 空间不足， 则只会写入部分字符串。

### 实例 ###
	buf = new Buffer(256);
	len = buf.write("www.runoob.com");
	
	console.log("写入字节数 : "+  len);

## 从缓冲区读取数据 ##
### 语法 ###
读取 Node 缓冲区数据的语法如下所示：

	buf.toString([encoding[, start[, end]]])
### 参数 ###

* **encoding** - 使用的编码。默认为 'utf8' 。
* **start** - 指定开始读取的索引位置，默认为 0。
* **end** - 结束位置，默认为缓冲区的末尾。

### 返回值 ###
解码缓冲区数据并使用指定的编码返回字符串。
### 实例 ###

	buf = new Buffer(26);
	for (var i = 0 ; i < 26 ; i++) {
	  buf[i] = i + 97;
	}
	
	console.log( buf.toString('ascii'));       // 输出: abcdefghijklmnopqrstuvwxyz
	console.log( buf.toString('ascii',0,5));   // 输出: abcde
	console.log( buf.toString('utf8',0,5));    // 输出: abcde
	console.log( buf.toString(undefined,0,5)); // 使用 'utf8' 编码, 并输出: abcde

## 将 Buffer 转换为 JSON 对象 ##

## 缓冲区合并 ##

## 缓冲区比较 ##

## 拷贝缓冲区 ##

## 缓冲区裁剪 ##

## 缓冲区长度 ##