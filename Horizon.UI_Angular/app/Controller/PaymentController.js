var PaymentController = function($scope, $http, FlightService) {
  $scope.clicked = function() {
    window.location = "#/confirmation";
  }
  $scope.book = FlightService.getBooking();

  $scope.addtobook = function() {

    FlightService.addBooking($scope.fields.first),
      FlightService.addBooking($scope.fields.last),
      FlightService.addBooking($scope.fields.phone),
      FlightService.addBooking($scope.fields.email),
      FlightService.addBooking($scope.fields.address),
      FlightService.addBooking($scope.fields.date),
      FlightService.addBooking($scope.fields.middle)
  };

  $scope.sendPost = function() {
    var jbook ={
        Email: $scope.fields.email,
        Firstname: $scope.fields.first,
        Middle: $scope.fields.middle,
        Lastname: $scope.fields.last,
        Birth_date: "09:00:00 00:00:00:0",
        Address: $scope.fields.address,
        Tel_num: $scope.fields.phone
    };
    var jsOne = JSON.stringify(jbook);
    console.log(jsOne)
    // $http.post('http://ec2-18-221-5-183.us-east-2.compute.amazonaws.com/logic/logicservice/passenger').success(function(jbook, status) {
    //   console.log("WORKS");
    // }).error(function(data, status) {
    //   $scope.status = status;
    // });
    $http({
        method: 'POST',
        url: 'http://ec2-18-221-5-183.us-east-2.compute.amazonaws.com/logic/logicservice/passenger',
        data: jsOne
      })
      .then(function successCallback(response) {});
  }



}

PaymentController.$inject = ['$scope', '$http', 'FlightService'];
// string Email
// string Firstname
// string Middle
// string Lastname
// System.DateTime Birth_date
// string Address
// string Tel_num
