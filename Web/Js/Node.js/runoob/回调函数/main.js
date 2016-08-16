// 阻塞代码实例
/*
var fs = require("fs");

var data = fs.readFileSync('input.txt');

console.log(data.toString());
console.log("程序执行结束!");
    */

// 非阻塞代码实例
var fs = require("fs");

fs.readFile('input.txt', function (error, data) {
    if (error) return console.log(error);
    console.log(data.toString());
});
console.log("程序执行结束!");