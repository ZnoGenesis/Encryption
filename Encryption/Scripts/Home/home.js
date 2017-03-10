var app = angular.module("App", []);

app.controller("homeCtrl", function ($scope, $http) {

   
    
    $scope.converter = {
        encode: function (){
            $http({
                url: "/Encryption/Base64Encode",
                method: "POST",
                params: {
                    plainText: $scope.encode_input
                }
            }).success(function (data) {                        
                $scope.encode = data
            })
        },
        decode: function () {
            $http({
                url: "/Encryption/Base64Decode",
                method: "POST",
                params: {
                    base64EncodedData: $scope.decode_input
                }
            }).success(function (data) {
                $scope.decode = data
            })
        }
    }
    $scope.name = "top"

    $scope.pj = [
        {
            id: 1,
            name: 'GITS',
            key: "Z2J4YXBwY3Q=",
            vector: "Z2l0czIwMDk="
        },
        {
            id : 2,
            name:'' ,
            key: "NOKEY",
            vector: "NO VECTOR"
        }
    ]
    console.log($scope.pj)
    $scope.project = [
        {
            id:0,
            name: "AppCtrl",
            key: [
                    { key: "Z2J4YXBwY3Q=", vector: "vector AppCtrl" },
                    { key: "Z2J4YXBwY3Q=", vector: "vector AppCtrl" },
                    { key: "Z2J4YXBwY3Q=", vector: "vector AppCtrl" }
            ]
        },
        {
            id:1,
            name: "GITS",
            key: [
                9,
                8,
                7
            ]
        }
    ]
    $scope.key = [
        { id: "1", key: "Z2J4YXBwY3Q=" },
        { id: "2", key: "Z2J4YXBwY3Q=" },
        { id: "3", key: "Z2J4YXBwY3Q=" }
    ];
    $scope.vector = [
        { id: "1", key: "Z2l0czIwMDk=" },
        { id: "2", key: "Z2l0czIwMDk=" },
        { id: "3", key: "Z2l0czIwMDk=" }
    ];
    $scope.Vector = ["Z2l0czIwMDk="];
    $scope.encryp = function () {
        console.log($scope.encrypt);
        $http.post("/Encryption/Encrypt", $scope.encrypt)
            .success(function (response) {
                $scope.encrypOutput = response;
            });       
    }
    $scope.mydecrypt = function () {
        console.log($scope.objdecrypt);
        $http.post("/Encryption/Decrypt", $scope.objdecrypt)
            .success(function (response) {
                $scope.decrypOutput = response;
            });
    }

    $scope.isFalse = function () {        
        return $scope.encrypt.key == null ? true : false;
    }
    $scope.dataIsNull = function () {
        return $scope.encrypt.Data == null ? true : false;
    }
})

