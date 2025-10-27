import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component/shop.component';
import { ProductsComponent } from './products.component/products.component';
import { InvoicesComponent } from './invoices.component/invoices.component';
import { OrdersComponent } from './orders.component/orders.component';
import { ShopService } from '../core/services/shop.service';
import { AdminLayoud } from './admin-layoud/admin-layoud';
import { ADMIN_ROUTES } from './pages.routes';
import { RouterModule } from '@angular/router';
import { OrderService } from '../core/services/order.service';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCardModule } from 'ng-zorro-antd/card';
import { OrderDetailComponent } from './order-detail.component/order-detail.component';
import { NzTagModule } from 'ng-zorro-antd/tag';



@NgModule({
  declarations: [
    ProductsComponent,
    InvoicesComponent,
    OrdersComponent,
    AdminLayoud,
    OrderDetailComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(ADMIN_ROUTES),
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    NzCardModule,
    NzTagModule

  ],
  providers: [ShopService, OrderService],
  exports: [
    ProductsComponent,
    InvoicesComponent,
    OrdersComponent,
    RouterModule,
    OrderDetailComponent
  ]
})
export class PagesModule { }
