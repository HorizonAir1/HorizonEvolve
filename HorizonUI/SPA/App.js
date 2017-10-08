var App = angular.module('App', ['ngRoute']);

App.controller('MainController', MainController);
App.controller('TableController', TableController);


var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'SPA/Views/main.html',
            controller: MainController
        })
        //.when('/flights', {
        //    templateUrl: 'SPA/Views/Table.html',
        //    controller: MainController
        //})
        //.when('/payment', {
        //    templateUrl: 'SPA/Views/Payment.html',
        //    controller: MainController
        //})
        //.when('/confirmation', {
        //    templateUrl: 'SPA/Views/Confirmation.html',
        //    controller: MainController
        //})
        .otherwise({
            redirectTo: function () {
                return '/';
            }
        });
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);