﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFHListView.Helper;
using XFHListView.Models;

namespace XFHListView.ViewModels
{
    public class SimpleGalleryPageViewModel : BindableBase
    {
        string[] images = {
                "https://farm9.staticflickr.com/8625/15806486058_7005d77438.jpg",
                "https://farm5.staticflickr.com/4011/4308181244_5ac3f8239b.jpg",
                "https://farm8.staticflickr.com/7423/8729135907_79599de8d8.jpg",
                "https://farm3.staticflickr.com/2475/4058009019_ecf305f546.jpg",
                "https://farm6.staticflickr.com/5117/14045101350_113edbe20b.jpg",
                "https://farm2.staticflickr.com/1227/1116750115_b66dc3830e.jpg",
                "https://farm8.staticflickr.com/7351/16355627795_204bf423e9.jpg",
                "https://farm1.staticflickr.com/44/117598011_250aa8ffb1.jpg",
                "https://farm8.staticflickr.com/7524/15620725287_3357e9db03.jpg",
                "https://farm9.staticflickr.com/8351/8299022203_de0cb894b0.jpg",
            };

        #region MyDatas
        private ObservableCollection<SampleItems1> _MyDatas;
        /// <summary>
        /// MyDatas
        /// </summary>
        public ObservableCollection<SampleItems1> MyDatas
        {
            get { return _MyDatas; }
            set { SetProperty(ref _MyDatas, value); }
        }
        #endregion

        #region 使用者點選項目
        private SampleItems1 _使用者點選項目;
        /// <summary>
        /// 使用者點選項目
        /// </summary>
        public SampleItems1 使用者點選項目
        {
            get { return this._使用者點選項目; }
            set { this.SetProperty(ref this._使用者點選項目, value); }
        }
        #endregion

        public DelegateCommand 使用者點選Command { get; set; }

        public readonly IPageDialogService _dialogService;
        public SimpleGalleryPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            Init();

            使用者點選Command = new DelegateCommand(() =>
            {
                _dialogService.DisplayAlertAsync("訊息", $"你選取的是 {使用者點選項目.Title}", "OK");
            });
        }

        public void Init()
        {
            MyDatas = new ObservableCollection<SampleItems1>();

            var howMany = new Random().Next(100, 500);

            for (int i = 0; i < howMany; i++)
            {
                var foo = i % 10;
                MyDatas.Add(new SampleItems1() {
                    Title = string.Format("項目 {0}", i),
                    ImageUrl = images[foo],
                    Color = RandomColor.PickColor
                });
            }
        }
    }
}
