import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PaymentDetailService } from 'src/app/payment-shared/payment-detail.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {
  

  constructor(public service:PaymentDetailService,
              private toastr:ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
      PMId: 0,
      CardOwnerName: '',
      CardNumber: '',
      ExpirationDate: '',
      CVV: ''
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.PMId == 0){
      this.createPayment(form);         // create a new entry (PMId = )
    }else{
      this.updatePayment(form);         // otherwise modify an entry (a non-zero PMId)
    }
  }
  
  createPayment(form: NgForm){
    delete form.value.PMId;
    
    this.service.postPaymentDetail(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Details submitted successfully', 'Payment App');
        this.service.refreshList();
      },
      err =>{
        console.log(err);
      }
    )
  }

  updatePayment(form: NgForm){
    this.service.putPaymentDetail(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Details updated successfully', 'Payment App');
        this.service.refreshList();
      },
      err =>{
        console.log(err);
      }
    )
  }

}
