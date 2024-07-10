
import { fadeInOut } from '../../services/animations';
import { Component, inject, OnInit, PipeTransform, TemplateRef, ViewEncapsulation } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {ItemService} from "../../services/item.service";
import {map, Observable, startWith } from 'rxjs';
import { DecimalPipe } from '@angular/common';
import {PublicHealthCentreService} from "../../services/public-health-centre.service";
import {RegionService} from "../../services/region.service";
import {PublicHealthCenter} from "../../models/public-health-center.model";

@Component({
  selector: 'app-customers',
  templateUrl: './public-health-center.component.html',
  styleUrl: './public-health-center.component.scss',
  animations: [fadeInOut],
})
export class PublicHealthCenterComponent implements OnInit {
  public itemForm;
  private modalService = inject(NgbModal);
  public listItem: PublicHealthCenter[] = [];
  public listProvince: Record<string, any>[] = [];
  public listCities: Record<string, any>[] = [];
  public listDistricts: Record<string, any>[] = [];
  public listVillages: Record<string, any>[] = [];

  filter = new FormControl('', { nonNullable: true });
  listItems$: Observable<PublicHealthCenter[]> = new Observable<PublicHealthCenter[]>();
  constructor(private fb: FormBuilder, public clinicService: PublicHealthCentreService, public regionService: RegionService) {    
    this.itemForm = this.fb.group({
      province: new FormControl('', [
        Validators.required
      ]),
      city: new FormControl('', [
        Validators.required
      ]),
      district: new FormControl('', [
        Validators.required
      ]),
      village: new FormControl('', [
        Validators.required
      ]),
      fkRegionId: new FormControl('', [
        Validators.required
      ]),
      clinicCode: new FormControl('', [
        Validators.required
      ]),
      name: new FormControl('', [
        Validators.required
      ]),
      nameHeadCenter: new FormControl('', [
        Validators.required
      ]),
      nipHeadCenter: new FormControl('', [
        Validators.required
      ]),
      phone: new FormControl('', [
        Validators.required
      ]),
      status: new FormControl('', [
        Validators.required
      ]),
    });
    this.listItems$ = this.filter.valueChanges.pipe(
        startWith(''),
        map((text) => this.search(text)),
    );
    this.itemForm?.get('province')?.valueChanges.subscribe(id => {
      this.listCities = [];
      this.listDistricts = [];
      this.listVillages = [];
      console.log(id)
      id && this.fetchCities(id);      
    });
    
    this.itemForm?.get('city')?.valueChanges.subscribe(id => {
      this.listDistricts = [];
      this.listVillages = [];
      id && this.fetchDistrict(id);
    });
    this.itemForm?.get('district')?.valueChanges.subscribe(id => {
      this.listVillages = [];
      id && this.fetchVillages(id);
    });
    this.itemForm?.get('village')?.valueChanges.subscribe(id => {
      this.itemForm?.get('fkRegionId')?.setValue(id);
    });
  }

  search(text: string): PublicHealthCenter[] {
    console.log("masuk sini")
    return this.listItem.filter((item) => {
      const term = text.toLowerCase();
      console.log(text, term)
      return (
          item['name'].toLowerCase().includes(term)
      );
    });
  }

  ngOnInit(): void {
    this.getListItems();
    this.fetchProvince();
  }
  
  getListItems() {
    this.clinicService.getListItem<PublicHealthCenter>().subscribe(res => {
      this.listItem = res;
      this.filter.setValue('');
    })
  }

  onSubmit(): void {
    let body: Record<string, any> = this.itemForm.value;
    body['region'] = this.listVillages.find(e => e['id'] === body['fkRegionId']);
    this.clinicService.addItem(this.itemForm.value).subscribe(res => {
      this.getListItems();
      this.itemForm.reset();
      this.modalService.dismissAll();
    })
  }
  openDialog(content: TemplateRef<any>) {
    this.modalService.open(content, { size: 'lg' });
  }
  
  fetchProvince() {
    this.regionService.getByParentId('0').subscribe(res => {
      this.listProvince = res;
    })
  }
  fetchCities(id: string) {
    this.regionService.getByParentId(id).subscribe(res => {
      this.listCities = res;
    })
  }
  fetchDistrict(id: string) {
    this.regionService.getByParentId(id).subscribe(res => {
      this.listDistricts = res;
    })
  }
  fetchVillages(id: string) {
    this.regionService.getByParentId(id).subscribe(res => {
      this.listVillages = res;
    })
  }
  transformAddress(row: PublicHealthCenter): string{
    return ` ${row?.region?.parent?.parent?.parent?.name}, ${row?.region?.parent?.parent?.name}, ${row?.region?.parent?.name}, ${row?.region?.name} `
  }
}