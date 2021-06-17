import { Component, OnInit } from '@angular/core';
import { searchService } from '../../_services/search.service'
import { SearchResult} from '../../_models/searchResult';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css'],
})
export class SearchResultComponent implements OnInit {

  searchResultList: Observable<SearchResult[]> | undefined;
  searchResult: Observable<SearchResult> | undefined;

  searchInProgress: boolean = false;
  gridLoading:boolean = false;

  constructor(
    private searchService: searchService,
  ) { }

  search(searchCriteria: string, companyName: string) {
    this.searchInProgress = true;
    this.searchResult = this.searchService.newSearch(searchCriteria, companyName)
      .pipe(tap({
        complete:() => this.searchCompleted()
      }));
  }

  private searchCompleted(){
    this.searchInProgress = false;
    this.gridLoading = true;
    
    this.searchResultList = this.searchService.getSearchHistory()
      .pipe(tap({
        complete:() => this.gridLoading = false
      }));
  }

  ngOnInit() {
    this.searchResultList = this.searchService.getSearchHistory();
  }

  trackElement(index: number, element: any) {
    return element ? element.guid : null;
  }
}