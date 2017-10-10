var ConfirmationController = function ($scope,FlightService) {
      $scope.book = FlightService.getBooking();

}

ConfirmationController.$inject = ['$scope','FlightService'];
