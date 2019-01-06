(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService']
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.AddProduct = AddProduct;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        };
        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.MoreImages);
            apiService.post('/api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + 'Đã được thêm mới');
                $state.go('products');
            }, function (error) {
                notificationService.displayError(error.data.Name + ' Thêm mới không thành công');
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
        loadProductCategories();
        $scope.MoreImages = [];
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
        }
})(angular.module('tshop.products'))