using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DK.Generator.Constants;
using DK.Generator.Entities;

namespace DK.Generator
{
    class Page
    {
        private String css { get; set; }
        private String html { get; set; }

        internal Page(IList<Site> sites)
        {
            if (sites.Any())
            {
                createLittleBalls(sites);

                createBigBall();
                createBody();
            }
        }


        private void createBody()
        {
            css = String.Format(@"
                body
                {{
                    margin: 0;
                    background: #{0};
                    text-align: center;
                }}{1}
            ", General.BodyColor, css);

            html = String.Format(
                @"<html>
                    <head>
                        <title>Dara Akeon</title>
                        <link type='text/css' rel='stylesheet' href='style.css' />
                        <script type='text/javascript' src='jquery.js'></script>
                        <script type='text/javascript' src='position.js'></script>
                    </head>
                    <body>{0}</body>
                </html>"
                , html);
        }


        private void createBigBall()
        {
            css = String.Format(@"
                .bigBall
                {{
                    width: {0}px;
                    height: {0}px;
                    background: #{2} url('fundo.gif') no-repeat center center;
                    display: none;
                    border-radius: {1}px;
                }}{3}
            "
            , BigBall.Size, BigBall.Size/2
            , BigBall.Color, css);

            html = String.Format(
                    "<div class='bigBall'>{0}</div>"
                    , html
                );
        }


        private void createLittleBalls(IList<Site> sites)
        {
            foreach (var site in sites)
            {
                var index = sites.IndexOf(site);
                var zindex = sites.Count - index;

                var top = calculateY(sites.Count, index);
                var left = calculateX(sites.Count, index);

                createLittleBall(site, index, zindex, top, left);
            }
        }

        private Int32 calculateX(Int32 total, Int32 index)
        {
            var angle = getAngle(total, index);

            var unit = Math.Cos(angle);

            return getRealPosition(unit);
        }

        private Int32 calculateY(Int32 total, Int32 index)
        {
            var angle = getAngle(total, index);

            var unit = Math.Sin(angle);

            return getRealPosition(unit);
        }

        private double getAngle(int total, int index)
        {
            var angleSize = Math.PI * 2 / total;

            var anglePosition = angleSize*index;

            var angleToStartFromLeft =
                anglePosition - Math.PI/2;

            return angleToStartFromLeft;
        }

        private int getRealPosition(double positionIndex)
        {
            var radiusOfBig = BigBall.Size / 2;
            var radiusOfLittle = LittleBall.Size / 2;

            var positionFromCenter = (Int32)(radiusOfBig * positionIndex);

            return positionFromCenter + radiusOfBig - radiusOfLittle;
        }

        private void createLittleBall(Site site, Int32 index, Int32 zindex, Int32 top, Int32 left)
        {
            css = String.Format(@"{0}
                .littleBall-{1}
                {{
                    position: relative;
                }}
                .littleBall-{1} a
                {{
                    width: {2}px;
                    height: {2}px;
                    border-radius: {3}px;
                    position: absolute;
                    top: {4}px;
                    left: {5}px;
                    background: #{7} url('{8}') no-repeat center center;
                    border: #{9} 2px solid;
                    z-index: {6};
                }}
            "
            , css, index
            , LittleBall.Size, LittleBall.Size / 2
            , top, left, zindex
            , site.Background, site.Image.LocalPath, site.Border);

            html = String.Format(@"
                {0}
                <div class='littleBall-{1}'>
                    <a href='{2}' target='_blank'></a>
                </div>
            ", html, index, site.Url);
        }




        internal void SaveFiles()
        {
            save("index.htm", html);
            save("style.css", css);
        }

        private static void save(String name, String content)
        {
            var path = Path.Combine(General.SitePath, name);

            using (var writer = new StreamWriter(path))
            {
                writer.Write(content);
            }

        }


    }
}
