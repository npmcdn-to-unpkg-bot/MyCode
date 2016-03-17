/**
 * name
 */
var object = (function () {
    function object(greeting) {
        this.greeting = greeting;
    }
    object.prototype.helloworld = function () {
        return "<h1>" + this.greeting + "</h1>";
    };
    return object;
}());
;
var greeter = new object("Hello, world");
document.body.innerHTML = greeter.helloworld();
