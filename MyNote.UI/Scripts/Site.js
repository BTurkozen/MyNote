//AngularJS Version
//uygulama başlatıldı.
var app = angular.module("myApp", ["ngRoute"]);

//route config
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", { templateUrl: "Pages/app.html", controller: "appController" })
        .when("/login", { templateUrl: "Pages/login.html", controller: "loginController" })
});

//htmlden sorumlu ana controller
app.controller("mainController", function ($scope) {
    $scope.test = "Hello main"
    $scope.checkAuth = function () {
        var tokenJson = localStorage["token"] | sessionStorage["token"];

        if (!tokenJson) {
            console.log("giriş yapılmamış");
            //Display Login/Register view
            return "";
        }

        //Check if token is valid

        //Display app view
    };

    $scope.checkAuth();
});

//login view
app.controller("loginController", function ($scope) {
    $scope.registerForm = {
        Email: "",
        Password: "",
        ConfirmPassword: ""
    };

    $scope.loginForm = {
        grant_type: "password",
        username: "",
        password: ""
    };

    $scope.rememberMe = false;

    $scope.registerSubmit = function () {
        alert("register submit");
    };

    $scope.loginSubmit = function (){
        alert("login submit");
    };
});

//app view
app.controller("appController", function ($scope, $location) {

    $location.path("/login"); // loginde işimiz bitince sileceğiz.
});


// JQuery Document Ready: Document hazır oldugunda bunu çalıştır 
$(function () {
    $(".navbar-login a").click(function (event) {
        event.preventDefault();
        var href = $(this).attr("href");
        // https://getbootstrap.com/docs/4.0/components/navs/#via-javascript
        $('#pills-tab a[href="' + href + '"]').tab('show'); // Select tab by name
    });

    $('body').on('click', '#pills-tab a', function (e) {
        e.preventDefault()
        $(this).tab('show')
    });
});

