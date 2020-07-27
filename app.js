var app = angular.module("ABET", ["ngRoute"]);
app.controller('mainCtrl', function ($scope, $http) {
    $scope.nextStore = 4;
    //$scope.stores = [{ id: 1, name: 'Fall2019' }, { id: 2, name: 'Spring2020' }, { id: 3, name: 'Summer2020' }];
    // $scope.classes[0] = {Id: 0, GroceryItem: 'Software Engineering 1', Brand: 'CEN 4020', Quantity: 120, Link: "Sonya P", StoreId: 1};
    $scope.nextGrocery = 0;
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

    $http({
        method: 'GET',
        url: 'api/Grocery/Get'
    }).then(function success(response) {
        $scope.groceries = response.data;
    }, function failure() {

    });

    $scope.selectStore = function (store) {
        $scope.addingStore = false;
        $scope.selectedGrocery = undefined;
        $scope.selectedStore = store;
    }

    // $scope.classes = [{ id: 0, grocery: { id: 0, courseName: 'Software Engineering 1', courseCode: 'CEN 4020' }, storeId: 2, link: 'Chris Mills', syllabus: null, canvasLink: '', quantity: 120 },
    //    { id: 1, grocery: { id: 1, courseName: 'C# Application Development', courseCode: 'CIS 4930' }, storeId: 1, link: 'Chris Mills', syllabus: null, canvasLink: '', quantity: 17 }];

    $scope.selectGrocery = function (cl) {
        $scope.addingGrocery = false;
        $scope.selectedGrocery = cl;
    }

    $scope.showNewGrocery = function () {
        $scope.addingGrocery = true;
        $scope.selectedGrocery = new Object();
        //  $scope.selectedGrocery.grocery = new Object();
    }

    $scope.showEditGrocery = function (cl) {
        $scope.editingGrocery = true;
        $scope.selectedGrocery = cl;
    }

    $scope.addGrocery = function () {
        $scope.selectedGrocery.storeId = $scope.selectedStore.Id;
        // $scope.classes.push($scope.selectedGrocery);
        $scope.selectedGrocery.Id = $scope.nextGrocery;


        $http({
            method: 'POST',
            url: 'api/Grocery/AddOrUp',
            data: $scope.selectedGrocery
        }).then(function success(response) {
            // $scope.classes.push(response.data);
            $scope.groceries[nextGrocery] = response.data;
        }, function failure() {

        });

        $scope.nextGrocery += 1;
        $scope.selectedGrocery = undefined;
        $scope.addingGrocery = false;

        $http({
            method: 'GET',
            url: 'api/Grocery/Get'
        }).then(function success(response) {
            $scope.groceries = response.data;
        }, function failure() {

        });

  
    }


    $scope.editGrocery = function (id) {
        $scope.selectedGrocery.storeId = $scope.selectedStore.Id;
        // $scope.classes.push($scope.selectedGrocery);
        $scope.selectedGrocery.Id = id;


        $http({
            method: 'POST',
            url: 'api/Grocery/AddOrUp',
            data: $scope.selectedGrocery
        }).then(function success(response) {
            // $scope.classes.push(response.data);
            $scope.groceries[id] = response.data;
        }, function failure() {

        });

        $scope.selectedGrocery = undefined;
        $scope.editingGrocery = false;
    }


    $scope.cancelAddGrocery = function () {
        $scope.selectedGrocery = undefined;
        $scope.addingGrocery = false;

    }
    $scope.cancelEdit = function () {
        $scope.selectedGrocery = undefined;
        $scope.editingGrocery = false;
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
            if ($scope.stores[i].Id === id) {
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
            if ($scope.groceries[i].Id === id) {
                indexToDelete = i;
                break;
            }
        }
        if (indexToDelete >= 0) {
            $scope.groceries.splice(indexToDelete, 1);
        }

        if ($scope.selectedGrocery.Id == id) {
            $scope.selectedGrocery = undefined;
        }
    }
});