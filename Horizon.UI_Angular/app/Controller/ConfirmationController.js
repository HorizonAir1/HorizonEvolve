var ConfirmationController = function ($scope,FlightService) {
      $scope.book = FlightService.getBooking();
      $scope.rand =Math.floor(Math.random()*100000001);

}

ConfirmationController.$inject = ['$scope','FlightService'];
