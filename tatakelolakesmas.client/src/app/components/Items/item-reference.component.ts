
import { fadeInOut } from '../../services/animations';
import { Component, inject, OnInit, PipeTransform, TemplateRef, ViewEncapsulation } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {ItemService} from "../../services/item.service";
import {map, Observable, startWith } from 'rxjs';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-customers',
  templateUrl: './item-reference.component.html',
  styleUrl: './item-reference.component.scss',
  animations: [fadeInOut],
})
export class ItemReferenceComponent implements OnInit {
  public itemForm;
  private modalService = inject(NgbModal);
  public listItem: Record<string, any>[] = [];
  

  filter = new FormControl('', { nonNullable: true });
  listItems$: Observable<Record<string,any>[]>;
  constructor(private fb: FormBuilder, public itemService: ItemService) {    
    this.itemForm = this.fb.group({
      code: new FormControl('', [
        Validators.required
      ]),
      name: new FormControl('', [
        Validators.required
      ]),
    });
    this.listItems$ = this.filter.valueChanges.pipe(
        startWith(''),
        map((text) => this.search(text)),
    );
  }

  search(text: string): Record<string, any>[] {
    console.log("masuk sini")
    return this.listItem.filter((item) => {
      const term = text.toLowerCase();
      console.log(text, term)
      return (
          item['name'].toLowerCase().includes(term),
          item['code'].toLowerCase().includes(term)
      );
    });
  }

  ngOnInit(): void {
    this.getListItems();
  }
  
  getListItems() {
    this.itemService.getListItem().subscribe(res => {
      this.listItem = res;
      console.log("ada data")
      this.filter.setValue('');
    })
  }

  onSubmit(): void {
    this.itemService.addItem(this.itemForm.value).subscribe(res => {
      this.getListItems();
      this.itemForm.reset();
      this.modalService.dismissAll();      
    })
  }
  openDialog	(content: TemplateRef<any>) {
    this.modalService.open(content, { size: 'lg' });
  }
}