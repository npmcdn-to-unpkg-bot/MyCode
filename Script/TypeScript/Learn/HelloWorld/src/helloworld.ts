/**
 * name
 */
class object {
    constructor(public greeting: string) { }
    helloworld(){
        return "<h1>" + this.greeting + "</h1>"
    }
};

var greeter = new object("Hello, world");

document.body.innerHTML = greeter.helloworld();