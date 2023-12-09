import { ActivatedRoute } from '@angular/router';
import { ShopService } from './../shop.service';
import { Component, OnInit, numberAttribute } from '@angular/core';
import { IProduct } from 'src/app/shared/Models/IProduct';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product!:IProduct;
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }
  ngOnInit(): void {
    this.loadProduct()
  }
  loadProduct() {
   let id=parseInt(this.activatedRoute.snapshot.paramMap.get('id')??'0')
    this.shopService.getProduct(id).subscribe({
      next: (response) => {
        this.product=response
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
