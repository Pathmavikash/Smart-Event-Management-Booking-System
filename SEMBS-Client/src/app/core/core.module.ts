import { NgModule, Optional, SkipSelf } from "@angular/core";
import { AuthService } from "./services/auth-service";
import { EventService } from "./services/event-service";

@NgModule({
  providers: [
    AuthService,
    EventService    
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parent: CoreModule) {
    if (parent) {
      throw new Error('CoreModule already loaded');
    }
  }

}
