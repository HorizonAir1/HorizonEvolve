var PaymentController = function ($scope,$http,FlightService) {
    $scope.clicked = function () {
        window.location = "#/confirmation";
    }
    $scope.book = FlightService.getBooking();

    $scope.addtobook = function(){

        FlightService.addBooking($scope.fields.first);
        FlightService.addBooking($scope.fields.last);
        FlightService.addBooking($scope.fields.phone);
        FlightService.addBooking($scope.fields.email);
    };

    $scope.sendPost = function() {
      var jbook = $.param({
            json: JSON.stringify({
                 passenger_email:"KIM@KIM.com",
                 flight_id:1,
                 seatclass_id:1,
                 seat_number:20,
                 baggage_num:2,
                 status_id:4
             })
          });
      console.log(jbook)
      $http.post('http://ec2-18-221-5-183.us-east-2.compute.amazonaws.com/logic/logicservice/booking').success(function(jbook, status) {
          console.log("WORKS");
      }).error(function (data, status) {
                    $scope.status = status;
                });
  }



}

PaymentController.$inject = ['$scope','$http','FlightService'];
//[booking_id] [int] IDENTITY(1,1) NOT NULL,
	// [passenger_id] [int] NOT NULL,
	// [flight_id] [int] NOT NULL,
	// [seatclass_id] [int] NOT NULL,
	// [seat_number] [int] NOT NULL,
	// [baggage_num] [int] NOT NULL,
	// [status_id] [int] NOT NULL,
