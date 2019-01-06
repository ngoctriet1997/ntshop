(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];
    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.product = {
           
        }
        $scope.UpdateProduct = UpdateProduct;
        $scope.MoreImages = [];
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };
        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.MoreImages);
            apiService.put('/api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + 'Đã được cập nhật');
                $state.go('products');
            }, function (error) {
                notificationService.displayError(error.data.Name + ' Cập nhật không thành công');
            });
        }
        $scope.GetTitleSeo = GetTitleSeo;
        function GetTitleSeo() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }
        $scope.productCategories = [];
        function loadProductCategories() {
            apiService.get('/api/productCategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        };
        $scope.ChooseMoreImage = ChooseMoreImage;
        function ChooseMoreImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.MoreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
        function loadProductDetail() {
            var config = {
                params: {
                    id: $stateParams.id
                }
            }
            apiService.get('/api/product/getbyid', config, function (result) {
                $scope.product = result.data;
                $scope.MoreImages = JSON.parse($scope.product.MoreImages);
                if ($scope.MoreImages == null) {
                    $scope.MoreImages = [];
                }
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }
        loadProductDetail();
        loadProductCategories();
    }
})(angular.module('tshop.products'))