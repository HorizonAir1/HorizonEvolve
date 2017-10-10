var PaymentController = function ($scope,$http,FlightService) {
    $scope.clicked = function () {
        window.location = "#/confirmation";
    }
    $scope.book = FlightService.getBooking();

    $scope.addtobook = function(){

        FlightService.addBooking($scope.fields);

    };
    // $http({
    //          url: 'http://ec2-18-221-5-183.us-east-2.compute.amazonaws.com/logic/logicservice/flight',
    //          method: "POST",
    //          data: postData,
    //          headers: {'Content-Type': 'application/x-www-form-urlencoded'}
    //      }).success(function (data, status, headers, config) {
    //              $scope.book = data; // assign  $scope.persons here as promise is resolved here
    //          }).error(function (data, status, headers, config) {
    //              $scope.status = status;
    //          });

}

PaymentController.$inject = ['$scope','$http','FlightService'];
// $scope.test = "Das ist ein Test";
//     $scope.groups = [{id: 142, name: 'Foo'},{id: 143, name: 'Bar'}, {id: 144, name: 'Bas'}];
//
//     $scope.contact = {name: 'Bob', groups: [{id: 143}]};
//     $scope.contact = {name: 'Bob', groups: $scope.groups[1]};
