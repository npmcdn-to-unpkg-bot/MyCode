var connect = require('connect');
var logger = require('morgan');
var app = connect()
    .use(logger("combined"))
    .use(function (req, res) {
        res.end('hello world\n');
    })
    .listen(3000);