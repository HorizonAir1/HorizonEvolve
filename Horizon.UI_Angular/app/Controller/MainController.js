var MainController = function ($scope,FlightService) {
    $scope.clicked = function () {
        window.location = "#/departures";
    }
    $scope.addtobook = function(currObj,currObj2){
        FlightService.addBooking(currObj);
        FlightService.addBooking(currObj2);
    };


}

MainController.$inject = ['$scope','FlightService'];
