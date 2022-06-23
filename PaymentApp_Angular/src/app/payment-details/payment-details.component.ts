import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../payment-shared/payment-detail.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styles: []
})
export class PaymentDetailsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
