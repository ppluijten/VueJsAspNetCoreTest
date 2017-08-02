var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import Vue from "vue";
import Component from "vue-class-component";
import axios from "axios";
var Hello = (function (_super) {
    __extends(Hello, _super);
    function Hello() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.msg = "Welcome to Your Vue.js App";
        return _this;
    }
    Hello.prototype.created = function () {
        var _this = this;
        axios.get("/api/hello")
            .then(function (res) {
            _this.msg = res.data.message;
        })
            .catch(function (ex) { return console.log(ex); });
    };
    Hello = __decorate([
        Component({
            name: "Hello"
        })
    ], Hello);
    return Hello;
}(Vue));
export default Hello;
