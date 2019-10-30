using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Services;
using Unity;

namespace ExtendedToolbarTest.Controls
{
    public class UserViewModel
    {
        public string Image { get; set; }

        private ICommand _ImagePressedCommand;

        public ICommand ImagePressedCommand =>
            _ImagePressedCommand ?? (_ImagePressedCommand = new DelegateCommand(() =>
                {
                    ContainerManager.Container.Resolve<IPageDialogService>()
                        .DisplayAlertAsync("Info", "Image pressed", "Ok");
                }));
    }
}
