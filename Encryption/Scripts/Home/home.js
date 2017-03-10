var app = angular.module("App", []);

app.controller("homeCtrl", function ($scope, $http) {



    $scope.converter = {
        encode: function () {
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

    function getDropdown() {
        var list = [
            {
                id: 1,
                name: 'GITS',
                key: "Q29ubmV4Nzg=",
                vector: "TXVuZXo2Nzg="
            },
            {
                id: 2,
                name: 'Appctrl',
                key: "Z2J4YXBwY3Q=",
                vector: "Z2l0czIwMDk="
            },
            {
                id: 3,
                name: 'Backoffice',
                key: "Q29ubmV4Nzg=",
                vector: "TXVuZXo2Nzg="
            }
        ]
        return list
    }
    $scope.pj = getDropdown()
    $scope.pjx = getDropdown()
    $scope.encryp = function () {
        console.log($scope.encrypt);
        $http.post("/Encryption/Encrypt", $scope.encrypt)
            .success(function (response) {
                $scope.encrypOutput = response;
            });
    }

    $scope.decryp = function () {
        console.log($scope.decrypt)
        $http.post("/Encryption/Decrypt", $scope.decrypt)
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

