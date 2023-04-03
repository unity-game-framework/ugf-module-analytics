# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-preview.3](https://github.com/unity-game-framework/ugf-module-analytics/releases/tag/1.0.0-preview.3) - 2023-04-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-analytics/milestone/4?closed=1)  
    

### Fixed

- Fix editor assembly definition  ([#7](https://github.com/unity-game-framework/ugf-module-analytics/issues/7))  
    - Fix _Editor_ assembly definition settings to be included in editor only platform.

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-module-analytics/releases/tag/1.0.0-preview.2) - 2023-04-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-analytics/milestone/3?closed=1)  
    

### Changed

- Change to user services module ([#5](https://github.com/unity-game-framework/ugf-module-analytics/issues/5))  
    - Update dependencies: `com.unity.services.analytics` to `4.4.1` and add `com.ugf.module.services` of `1.0.0-preview.1` version.
    - Update package _Unity_ version to `2022.2`.
    - Add `AnalyticsEventDescription` class as description of the event.
    - Add `IAnalyticsModule.SendEvent()` methods to send event by description id.
    - Remove `AnalyticsUnityModule` initialization of the global services, `IServicesModule` used instead.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-module-analytics/releases/tag/1.0.0-preview.1) - 2022-05-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-analytics/milestone/2?closed=1)  
    

### Added

- Add logs ([#3](https://github.com/unity-game-framework/ugf-module-analytics/issues/3))  
    - Change `AnalyticsModule` class to logs enable and disable states.
    - Change `AnalyticsUnityModule` class to logs result of enable.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-module-analytics/releases/tag/1.0.0-preview) - 2022-05-29  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-analytics/milestone/1?closed=1)  
    

### Added

- Add implementation ([#1](https://github.com/unity-game-framework/ugf-module-analytics/issues/1))  
    - Update package _Unity_ version to `2022.1`.
    - Add `IAnalyticsModule` interface to implement analytics module.
    - Add `AnalyticsUnityModule` class as implementation of analytics using _Unity_ services.


