var app = angular.module("ABET", ["ngRoute"]);
app.controller('mainCtrl', function ($scope, $http) {
    $scope.nextStore = 4;
    //$scope.semesters = [{ id: 1, name: 'Fall2019' }, { id: 2, name: 'Spring2020' }, { id: 3, name: 'Summer2020' }];
    $scope.nextGrocery = 4;
    $http({
        method: 'GET',
        url: 'api/Store/Get'
    }).then(function success(response) {
        $scope.stores = response.data;
    }, function failure() {

    });

    $http({
        method: 'GET',
        url: 'api/Store/GetById/2'
    }).then(function success(response) {
        $scope.selectedStore = response.data;
    }, function failure() {

    });



    $scope.selectStore = function (store) {
        $scope.addingStore = false;
        $scope.selectedGroc = undefined;
        $scope.selectedStore = store;
    }

    // $scope.classes = [{ id: 0, course: { id: 0, courseName: 'Software Engineering 1', courseCode: 'CEN 4020' }, semesterId: 2, instructor: 'Chris Mills', syllabus: null, canvasLink: '', enrollment: 120 },
    //    { id: 1, course: { id: 1, courseName: 'C# Application Development', courseCode: 'CIS 4930' }, semesterId: 1, instructor: 'Chris Mills', syllabus: null, canvasLink: '', enrollment: 17 }];

    $scope.selectGrocery = function (groc) {
        $scope.addingGrocery = false;
        $scope.selectedGrocery = groc;
    }

    $scope.showNewGrocery = function () {
        $scope.addingGrocery = true;
        $scope.selectedGrocery = new Object();
        $scope.selectedGrocery.grocery = new Object();
    }

    $scope.addGrocry = function () {
        $scope.selectedGrocery.storeId = $scope.selectedStore.Id;
        // $scope.classes.push($scope.selectedClass);
        $scope.selectedGrocery.id = $scope.nextGrocery;
        $scope.nextGrocery += 1;

        $http({
            method: 'POST',
            url: 'api/Grocery/AddOrUpdate',
            data: $scope.selectedGrocery
        }).then(function success(response) {
            $scope.groceries.push(response.data);
        }, function failure() {

        });

        $scope.selectedGrocery = undefined;
        $scope.addingGrocery = false;
    }

    $scope.cancelAddGrocery = function () {
        $scope.selectedGrocery = undefined;
        $scope.addingGrocery = false;
    }

    $scope.showNewStore = function () {
        $scope.selectedStore = undefined;
        $scope.addingStore = true;
    }
    $scope.addStore = function () {
        $scope.selectedStore.id = $scope.nextStore;
        $scope.nextStore += 1;


        $http({
            method: 'POST',
            url: 'api/Store/AddOrUpdate',
            data: $scope.selectedStore
        }).then(function success(response) {
            $scope.stores.push(response.data);
        }, function failure() {

        });

        $scope.selectedStore = undefined;
        $scope.addingStore = false;
    }

    $scope.cancelAddStore = function () {
        $scope.selectedStore = undefined;
        $scope.addingStore = false;
    }

    $scope.removeStore = function (id) {
        var indexToDelete = -1;
        for (i = 0; i < $scope.stores.length; i++) {
            if ($scope.stores[i].id === id) {
                indexToDelete = i;
                break;
            }
        }
        if (indexToDelete >= 0) {
            $scope.stores.splice(indexToDelete, 1);
        }

    }

    $scope.removeGrocery = function (id) {
        var indexToDelete = -1;
        for (i = 0; i < $scope.groceries.length; i++) {
            if ($scope.groceries[i].id === id) {
                indexToDelete = i;
                break;
            }
        }
        if (indexToDelete >= 0) {
            $scope.groceries.splice(indexToDelete, 1);
        }

        if ($scope.selectedGrocery.id == id) {
            $scope.selectedGrocery = undefined;
        }
    }
});