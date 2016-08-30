var express = require("express");
// var session = require('express-session')
var app = express();
app.set('trust proxy', 1); // trust first proxy
app.use(express.session({
    secret: 'keyboard cat',
    resave: false,
    saveUninitialized: true,
    cookie: { secure: true }
}));