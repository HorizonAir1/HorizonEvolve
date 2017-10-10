var TableController = function ($scope,$http,FlightService) {
    $scope.clicked = function () {
        window.location = "#/arrivals";
    }
    $http.get('http://ec2-18-221-5-183.us-east-2.compute.amazonaws.com/logic/logicservice/flight').
        success(function (data, status, headers, config) {
            $scope.flights = data;
        }).
        error(function (data, status, headers, config) {
            alert("error");
        });
    $scope.addtobook = function(currObj){

        FlightService.addBooking(currObj);

    };



}

TableController.$inject = ['$scope','$http','FlightService'];


//GET FACTORY ITEM
// app.controller('CartController', function($scope, productService) {
//     $scope.products = productService.getProducts();
// });
