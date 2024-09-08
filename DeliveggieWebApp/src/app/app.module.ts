import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { DayOfWeekPipe } from './pipe/day-of-week.pipe';
import { EuroCurrencyPipe } from './pipe/euro-currency.pipe';

//Routing settings.
const appRoutes: Routes = [
  { path: 'products', component: ProductListComponent },
  { path: 'product-details/:id', component: ProductDetailsComponent },
  { path: '', redirectTo: '/products', pathMatch: 'full' },  // Redirect to product list by default
  { path: '**', redirectTo: '/products' }  // Fallback route for unknown paths
];

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductDetailsComponent,
    DayOfWeekPipe,
    EuroCurrencyPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,  // Import HttpClientModule to perform HTTP requests
    RouterModule.forRoot(appRoutes)  // Set up routing with the defined routes
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
