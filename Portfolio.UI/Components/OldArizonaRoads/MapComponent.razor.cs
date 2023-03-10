﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio.Shared.Models;

namespace Portfolio.UI.Components
{
    public partial class MapComponent
    {
        [Parameter]
        public MapModel? Map { get; set; }

        private string GetFullDescription() => $"{Map?.Month?.Trim()} {Map?.Year?.Trim()} {Map?.State?.Trim()} {Map?.Description?.Trim()}";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!string.IsNullOrWhiteSpace(Map?.Url))
            {
                await JSRuntime.InvokeVoidAsync("jsInterop.loadZoomify", new object[] { Map.Url });
            }
        }
    }
}