import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserDetailService } from 'src/app/user-shared/user-detail.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styles: [],
})
export class UserDetailComponent implements OnInit {
  constructor(
    public service: UserDetailService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) form.form.reset();
    this.service.formData = {
      UserId: 0,
      UserDateCreated: '',
      FirstName: '',
      LastName: '',
      DateOfBirth: '',
    };
  }

  onSubmit(form: NgForm) {
    if (form.value.PMId == 0) {
      this.createUser(form); // create a new entry (PMId = )
    } else {
      this.updateUser(form); // otherwise modify an entry (a non-zero PMId)
    }
  }

  createUser(form: NgForm) {
    delete form.value.UserId;

    this.service.postUserDetail(form.value).subscribe(
      (res) => {
        this.resetForm(form);
        this.toastr.success('Details submitted successfully', 'User Form');
        this.service.refreshList();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  updateUser(form: NgForm) {
    this.service.putUserDetail(form.value).subscribe(
      (res) => {
        this.resetForm(form);
        this.toastr.info('Details updated successfully', 'USer Form');
        this.service.refreshList();
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
