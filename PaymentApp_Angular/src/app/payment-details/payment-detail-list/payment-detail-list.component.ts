import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from 'src/app/payment-shared/payment-detail.model';
import { PaymentDetailService } from 'src/app/payment-shared/payment-detail.service';

@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: [],
})
export class PaymentDetailListComponent implements OnInit {
  constructor(
    public service: PaymentDetailService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(pd: PaymentDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  deletePayment(PMId) {
    if (confirm('Are you sure you want to delete this entry?')) {
      this.service.deletePaymentDetail(PMId).subscribe(
        (res) => {
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'Payment Detail Form');
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }
}
