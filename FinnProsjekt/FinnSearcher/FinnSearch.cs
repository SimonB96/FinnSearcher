using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinnScraper
{
    public class PagingLink
    {
        public string label { get; set; }
        public string url { get; set; }
        public bool active { get; set; }
    }

    public class FirstPage
    {
        public string label { get; set; }
        public string url { get; set; }
        public bool active { get; set; }
    }

    public class NextPage
    {
        public string label { get; set; }
        public string url { get; set; }
        public bool active { get; set; }
    }

    public class PagingInfo
    {
        public List<PagingLink> pagingLinks { get; set; }
        public int currentPageIndex { get; set; }
        public int lastPageIndex { get; set; }
        public object previousPage { get; set; }
        public FirstPage firstPage { get; set; }
        public NextPage nextPage { get; set; }
        public bool hasPaging { get; set; }
    }

    public class PositionThresholds
    {
        public string netboard_3 { get; set; }
        public string netboard_2 { get; set; }
        public string netboard_1 { get; set; }
    }

    public class Urls
    {
    }

    public class PositionThresholds2
    {
        public string netboard_3 { get; set; }
        public string netboard_2 { get; set; }
        public string netboard_1 { get; set; }
    }

    public class BannerData
    {
        public object error { get; set; }
        public object feedString { get; set; }
        public object positions { get; set; }
        public object feed { get; set; }
        public Urls urls { get; set; }
        public PositionThresholds2 positionThresholds { get; set; }
        public string adserver { get; set; }
        public object objectUrl { get; set; }
        public string jsonFeed { get; set; }
        public string appNexusJson { get; set; }
        public bool banner { get; set; }
        public bool mobileOrTablet { get; set; }
        public bool nativeAdEnabled { get; set; }
        public bool htmlBanner { get; set; }
    }

    public class MediaCategory
    {
        public object scheme { get; set; }
        public object label { get; set; }
        public object text { get; set; }
    }

    public class Image
    {
        public object type { get; set; }
        public string url { get; set; }
        public object description { get; set; }
        public object title { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public MediaCategory mediaCategory { get; set; }
    }

    public class Opengraph
    {
        public string description { get; set; }
        public string title { get; set; }
        public string seoText { get; set; }
        public Image image { get; set; }
        public string twitterCardType { get; set; }
    }

    public class Child
    {
        public string name { get; set; }
        public string value { get; set; }
        public List<object> children { get; set; }
        public string hitCount { get; set; }
        public string label { get; set; }
        public bool? hasHits { get; set; }
        public bool? selected { get; set; }
        public bool? popular { get; set; }
        public bool? hasPopular { get; set; }
    }

    public class Root
    {
        public string name { get; set; }
        public string value { get; set; }
        public List<Child> children { get; set; }
        public string hitCount { get; set; }
        public object label { get; set; }
        public bool? hasHits { get; set; }
        public bool? selected { get; set; }
        public bool? popular { get; set; }
        public bool? hasPopular { get; set; }
    }

    public class FilterWidget
    {
        public string name { get; set; }
        public string label { get; set; }
        public string placeholder { get; set; }
        public string currentValue { get; set; }
        public string autoSuggestKey { get; set; }
        public bool queryWidget { get; set; }
        public bool selected { get; set; }
        public string summary { get; set; }
        public string widgetType { get; set; }
        public bool hidden { get; set; }
        public Root root { get; set; }
        public bool? taxonomyTreeWidget { get; set; }
        public string radius { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public object locationName { get; set; }
        public bool? geoWidget { get; set; }
        public bool? moreFilter { get; set; }
        public bool? taxonomyWidget { get; set; }
        public string id { get; set; }
        public string labelUnit { get; set; }
        public string rangeMin { get; set; }
        public string rangeMax { get; set; }
        public string step { get; set; }
        public string formattedRangeMin { get; set; }
        public string formattedRangeMax { get; set; }
        public string lowerEndpointText { get; set; }
        public string upperEndpointText { get; set; }
        public string fieldNameMin { get; set; }
        public string fieldNameMax { get; set; }
        public object currentMinValue { get; set; }
        public object currentMaxValue { get; set; }
        public object formattedCurrentMinValue { get; set; }
        public object formattedCurrentMaxValue { get; set; }
        public bool? formatNumber { get; set; }
        public bool? rangeWidget { get; set; }
    }

    public class QueryParams
    {
        public List<string> search_type { get; set; }
    }

    public class SegmentModel
    {
        public string title { get; set; }
        public string vertical { get; set; }
        public string segment { get; set; }
        public string searchKey { get; set; }
        public QueryParams queryParams { get; set; }
        public string baseSearchUrl { get; set; }
        public string verticalAndSegment { get; set; }
    }

    public class SortValue
    {
        public string value { get; set; }
        public string description { get; set; }
        public bool selected { get; set; }
    }

    public class Filters
    {
        public string query { get; set; }
        public string sorting { get; set; }
        public string numResults { get; set; }
    }

    public class PulseOptionsKey
    {
        public string contentType { get; set; }
        public Filters filters { get; set; }
    }

    public class TopRowLeft
    {
        public string displayText { get; set; }
        public string displayFullText { get; set; }
        public bool displayStatusOrPublished { get; set; }
        public bool displayDeadline { get; set; }
        public bool disposed { get; set; }
    }

    public class DisplaySearchResult
    {
        public int adId { get; set; }
        public string imageUrl { get; set; }
        public string adUrl { get; set; }
        public string topRowCenter { get; set; }
        public TopRowLeft topRowLeft { get; set; }
        public string topRowRight { get; set; }
        public string titleRow { get; set; }
        public List<string> bodyRow { get; set; }
        public string bottomRow1 { get; set; }
        public object bottomRow2 { get; set; }
        public object bottomRow3 { get; set; }
        public bool disallowImageCropping { get; set; }
        public bool promoted { get; set; }
        public bool vipPromoted { get; set; }
        public bool showingTodayPromoted { get; set; }
        public bool calendarPromoted { get; set; }
        public bool bapWebStore { get; set; }
        public object logoUrl { get; set; }
        public object clickCounter { get; set; }
        public object viewCounter { get; set; }
        public object clickWebstatCounter { get; set; }
        public object viewWebstatCounter { get; set; }
        public object saveCounter { get; set; }
        public object emailCounter { get; set; }
        public int listPosition { get; set; }
        public string imageSrcSet { get; set; }
        public bool hasImg { get; set; }
        public int daysLeft { get; set; }
        public object disposedDescription { get; set; }
        public bool classifiedAd { get; set; }
        public bool editableInNewPlatform { get; set; }
        public string adTypeTerm { get; set; }
        public object headerForProjectPrice { get; set; }
        public object imageRatio { get; set; }
        public bool anyPromotedType { get; set; }
        public bool landscapeFormat { get; set; }
        public bool portraitFormat { get; set; }
        public bool squareFormat { get; set; }
        public string positionThreshold { get; set; }
        public string bannerPosition { get; set; }
        public bool? isBanner { get; set; }
        public bool? showBanner { get; set; }
        public int? positionIndex { get; set; }
    }

    public class FinnSearch
    {
        public PagingInfo pagingInfo { get; set; }
        public int objectCount { get; set; }
        public string hitName { get; set; }
        public PositionThresholds positionThresholds { get; set; }
        public string pageTitle { get; set; }
        public string vertical { get; set; }
        public string lon { get; set; }
        public string appNexusNAM { get; set; }
        public BannerData bannerData { get; set; }
        public bool showSaveSearch { get; set; }
        public string uuid { get; set; }
        public bool hasHorseshoeBanner { get; set; }
        public bool bapResultPageGridEnabled { get; set; }
        public string subTitle { get; set; }
        public bool showBanner { get; set; }
        public bool showFirstPagingLink { get; set; }
        public string savedSearchSuggestionTitle { get; set; }
        public string verticalTitle { get; set; }
        public string appNexusJson { get; set; }
        public string lat { get; set; }
        public Opengraph opengraph { get; set; }
        public bool showSaveSearchTeaser { get; set; }
        public List<FilterWidget> filterWidgets { get; set; }
        public bool showAdSenseForShopping { get; set; }
        public bool hasGridLayout { get; set; }
        public string selfUrl { get; set; }
        public SegmentModel segmentModel { get; set; }
        public bool isContextSpecificFiltersEnabled { get; set; }
        public string searchKey { get; set; }
        public List<SortValue> sortValues { get; set; }
        public int hits { get; set; }
        public string feed { get; set; }
        public PulseOptionsKey pulseOptionsKey { get; set; }
        public bool showSort { get; set; }
        public bool fullscreenMapSearch { get; set; }
        public string mapUrl { get; set; }
        public bool displayObjectCount { get; set; }
        public string objectName { get; set; }
        public List<DisplaySearchResult> displaySearchResults { get; set; }
        public string time { get; set; }
        public bool isSearchStorable { get; set; }
        public string searchVersion { get; set; }
        public bool showCurrentPagingIndex { get; set; }
    }
}