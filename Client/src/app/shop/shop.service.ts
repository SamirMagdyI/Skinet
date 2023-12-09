import { IProductType } from './../shared/Models/IProductType';
import { IBrand } from './../shared/Models/IBrand';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/Models/IPagination';
import { map } from 'rxjs/internal/operators/map';
import { ShopParams } from '../shared/Models/ShopParams';
import { IProduct } from '../shared/Models/IProduct';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:7009/api/';

  constructor(private http: HttpClient) {}

  getProducts(ShopParams: ShopParams) {
    let params = new HttpParams();
    if (ShopParams.brandId) {
      params = params.append('BrandId', ShopParams.brandId.toString());
    }
    if (ShopParams.productTypeId) {
      params = params.append('typeId', ShopParams.productTypeId.toString());
    }
    if (ShopParams.sort) {
      params = params.append('Sort', ShopParams.sort);
    }
    if(ShopParams.search){
      params = params.append("Search",ShopParams.search)
    }
    params=params.append("PageIndex",ShopParams.pageNumber.toString())
    params=params.append("PageSize",ShopParams.pageSize.toString())

    return this.http
      .get<IPagination>(this.baseUrl + 'Products', {
        observe: 'response',
        params: params,
      })
      .pipe(map((response) => response.body));
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'Products/' + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Products/brands');
  }
  getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'Products/types');
  }
}
