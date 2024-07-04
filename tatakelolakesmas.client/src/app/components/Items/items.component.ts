
import { fadeInOut } from '../../services/animations';
import { Component, inject, OnInit, TemplateRef, ViewEncapsulation } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {ItemService} from "../../services/item.service";

@Component({
  selector: 'app-customers',
  templateUrl: './items.component.html',
  styleUrl: './items.component.scss',
  animations: [fadeInOut]
})
export class ItemsComponent implements OnInit {
  public itemForm;
  private modalService = inject(NgbModal);
  public listItem: Record<string, any>[] = [];

  constructor(private fb: FormBuilder, public itemService: ItemService) {    
    this.itemForm = this.fb.group({
      kodeBarang: new FormControl('', [
        Validators.required
      ]),
      namaBarang: new FormControl('', [
        Validators.required
      ]),
    });
  }

  ngOnInit(): void {
    this.getListItems();
  }
  
  getListItems() {
    this.itemService.getListItem().subscribe(res => {
      console.log(res)
    })
  }

  onSubmit(): void {
    this.itemService.addItem(this.itemForm.value).subscribe(res => {
      console.log(res)
    })
  }
  openDialog	(content: TemplateRef<any>) {
    this.modalService.open(content, { size: 'lg' });
  }
}