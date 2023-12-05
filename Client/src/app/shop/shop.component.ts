import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { IProduct } from '../shared/Models/IProduct';
import { IBrand } from '../shared/Models/IBrand';
import { IProductType } from '../shared/Models/IProductType';
import { ShopParams } from '../shared/Models/ShopParams';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  brands!: IBrand[];
  productTypes!: IProductType[];
  shopParams=new ShopParams();
  totalCount!:number;
 
  sortOptions = [
    { name: 'name', value: 'alphabetical' },
    { name: 'Price: High To Low', value: 'priceAsc' },
    { name: 'Price: Low To High', value: 'priceDesc' },
  ];

  constructor(private ShopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.ShopService.getProducts(this.shopParams).subscribe({
      next: (response) => {
        this.products = response?.data ?? [];
        this.shopParams.pageNumber=response?.pageIndex?? 1 ;
        this.shopParams.pageSize=response?.pageSize?? 0 ;
        this.totalCount=response?.count?? 0 ;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  getBrands() {
    this.ShopService.getBrands().subscribe({
      next: (response) => {
        this.brands = [{ id: 0, name: 'ALL' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  getProductTypes() {
    this.ShopService.getProductTypes().subscribe({
      next: (response) => {
        this.productTypes = [{ id: 0, name: 'ALL' }, ...response];
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  onBrandIdSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }
  onProductTypeIdSelected(productTypeIdSelected: number) {
    this.shopParams.productTypeId = productTypeIdSelected;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }
  onSortSelected(){
    this.getProducts();
  }
  onPageChanged(event:any){
    if(event!=this.shopParams.pageNumber){
      this.shopParams.pageNumber=event;
      this.getProducts()
    }
  }
  onSearch(){
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  onReset(){
    this.shopParams.search="";
    this.shopParams=new ShopParams();
    this.getProducts();
  }
}
